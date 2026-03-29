
using DaintStudio.Models;
using DaintStudio.Services.Common;
using System.Security.Cryptography;
using System.Text;

namespace DaintStudio.Services.Blockchain;

public class GateIoClient
{
    private static KeyModel data = FileHelper.Read<KeyModel>(@"D:\ApiGateway\data\secret_keys\gate_io\key.json");

    private readonly string _apiKey = data.key!;
    private readonly string _apiSecret = data.secret!;
    private readonly string _host = "https://api.gateio.ws";
    private readonly string _prefix = "/api/v4";

    private string HashSha512(string input)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }

    private string CreateHmacSha512(string secret, string message)
    {
        byte[] keyByte = Encoding.UTF8.GetBytes(secret);
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);
        using (var hmacsha512 = new HMACSHA512(keyByte))
        {
            byte[] hashmessage = hmacsha512.ComputeHash(messageBytes);
            return BitConverter.ToString(hashmessage).Replace("-", "").ToLower();
        }
    }
    public async Task<string> GetSpotBalance()
    {
        string method = "GET";
        string endpoint = "/spot/accounts"; // KHÔNG bao gồm prefix /api/v4 ở đây nếu dùng trong chuỗi ký tùy version, nhưng Gate v4 yêu cầu FULL PATH sau domain.
        string fullPath = _prefix + endpoint;
        string queryString = ""; // Để trống nếu không có tham số

        // 1. Hash của body rỗng (Dành cho GET)
        // Giá trị này là cố định cho chuỗi rỗng: cf83e1357eef...
        string bodyHash = HashSha512("");

        // 2. Lấy Timestamp
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        // 3. Tạo chuỗi ký - QUAN TRỌNG: Cấu trúc 5 dòng
        // Dòng 2 phải là FULL PATH (ví dụ: /api/v4/spot/accounts)
        string signatureString = $"{method}\n{fullPath}\n{queryString}\n{bodyHash}\n{timestamp}";

        // 4. Tạo HMAC-SHA512
        string signature = CreateHmacSha512(_apiSecret, signatureString);

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _host + fullPath);

            request.Headers.Add("KEY", _apiKey);
            request.Headers.Add("SIGN", signature);
            request.Headers.Add("Timestamp", timestamp);
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
    public async Task<string> GetFutureBalance()
    {
        string method = "GET";
        string endpoint = "/futures/usdt/accounts";
        string fullPath = _prefix + endpoint;
        string queryString = ""; // không có tham số

        // 1. Hash body rỗng
        string bodyHash = HashSha512("");

        // 2. Timestamp
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        // 3. Chuỗi ký
        string signatureString = $"{method}\n{fullPath}\n{queryString}\n{bodyHash}\n{timestamp}";

        // 4. Tạo HMAC-SHA512
        string signature = CreateHmacSha512(_apiSecret, signatureString);

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _host + fullPath);

            request.Headers.Add("KEY", _apiKey);
            request.Headers.Add("SIGN", signature);
            request.Headers.Add("Timestamp", timestamp);
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }

    public async Task<string> GetFuturePositions()
    {
        // Endpoint để lấy tất cả vị thế đang mở của tài khoản Futures USDT
        string method = "GET";
        string endpoint = "/futures/usdt/positions";
        string fullPath = _prefix + endpoint;
        string queryString = ""; // Để trống nếu muốn lấy tất cả, hoặc thêm "settle=usdt" nếu cần lọc

        // 1. Hash body rỗng cho phương thức GET
        string bodyHash = HashSha512("");

        // 2. Lấy Timestamp hiện tại
        string timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();

        // 3. Tạo chuỗi ký (Signature String) theo chuẩn Gate v4
        // Cấu trúc: METHOD + \n + PATH + \n + QUERY_STRING + \n + HEX_BODY_HASH + \n + TIMESTAMP
        string signatureString = $"{method}\n{fullPath}\n{queryString}\n{bodyHash}\n{timestamp}";

        // 4. Tạo HMAC-SHA512 signature
        string signature = CreateHmacSha512(_apiSecret, signatureString);

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _host + fullPath);

            // Thêm các Header bắt buộc
            request.Headers.Add("KEY", _apiKey);
            request.Headers.Add("SIGN", signature);
            request.Headers.Add("Timestamp", timestamp);
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
