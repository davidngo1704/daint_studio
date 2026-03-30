using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DaintStudio.Services.Blockchain;

public class BingXClient
{
    private string _apiKey = string.Empty!;
    private string _apiSecret = string.Empty!;


    private readonly string _baseUrl = "https://open-api.bingx.com"; // Dùng https://open-api-vst.bingx.com cho demo
    private readonly HttpClient _httpClient;

    public BingXClient(string apiKey, string apiSecret, bool isDemo = false)
    {
        _apiKey = apiKey;
        _apiSecret = apiSecret;
        if (isDemo) _baseUrl = "https://open-api-vst.bingx.com";
        _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        _httpClient.DefaultRequestHeaders.Add("X-BX-APIKEY", _apiKey);
    }

    /// <summary>
    /// Đồng bộ thời gian server BingX (rất quan trọng để tránh lỗi timestamp)
    /// </summary>
    public async Task<long> GetServerTimeAsync()
    {
        try
        {
            // Tạo request riêng không dùng default header API Key
            using var request = new HttpRequestMessage(HttpMethod.Get, "/openApi/swap/v2/serverTime");
            var response = await _httpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"[BingX] ServerTime failed: {response.StatusCode} - {content}");
                return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            }

            var json = JsonConvert.DeserializeObject<dynamic>(content);

            if (json?.code == 0)
            {
                long serverTime = (long)json.data.serverTime;
                Console.WriteLine($"[BingX] Server time synced: {serverTime}");
                return serverTime;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[BingX] GetServerTime exception: {ex.Message}");
        }

        // Fallback về thời gian local (UTC)
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    /// <summary>
    /// Tạo chữ ký HMAC SHA256 theo quy tắc của BingX
    /// </summary>
    private string GenerateSignature(string queryString)
    {
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_apiSecret));
        byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(queryString));
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }

    /// <summary>
    /// Hàm chung gửi request signed (GET)
    /// </summary>
    private async Task<string> SendSignedRequestAsync(string path, Dictionary<string, object> parameters = null)
    {
        long timestamp = await GetServerTimeAsync(); // Đồng bộ time server

        if (parameters == null) parameters = new Dictionary<string, object>();
        parameters["timestamp"] = timestamp;
        parameters["recvWindow"] = 10000; // 10 giây, có thể điều chỉnh

        // Sắp xếp key theo thứ tự alphabet
        var sortedParams = parameters
            .OrderBy(x => x.Key)
            .Select(x => $"{x.Key}={x.Value}")
            .ToList();

        string queryString = string.Join("&", sortedParams);

        string signature = GenerateSignature(queryString);

        string fullUrl = $"{path}?{queryString}&signature={signature}";

        var response = await _httpClient.GetAsync(fullUrl);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            throw new Exception($"BingX API Error: {response.StatusCode} - {responseContent}");

        return responseContent;
    }

    /// <summary>
    /// LẤY THÔNG TIN VỊ THẾ FUTURE (tất cả hoặc theo symbol)
    /// </summary>
    public async Task<string> GetFuturesPositionsAsync(string symbol = null)
    {
        var parameters = new Dictionary<string, object>();

        if (!string.IsNullOrEmpty(symbol))
            parameters["symbol"] = symbol;   // ví dụ: "BTC-USDT"

        string json = await SendSignedRequestAsync("/openApi/swap/v2/user/positions", parameters);

        // Parse JSON nếu cần (dùng model class hoặc dynamic)
        return json;
    }

}