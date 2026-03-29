
using System.Text.Json.Serialization;

namespace DaintStudio.Models;

public class SpotBalance
{
    public string? currency { get; set; }
    public decimal available { get; set; }
}
public class FutureBalance
{
    public decimal unrealised_pnl { get; set; }
    public decimal total { get; set; }
}
public class TradePosition
{
    [JsonPropertyName("value")]
    public string? value { get; set; }

    [JsonPropertyName("leverage")]
    public string? leverage { get; set; }

    [JsonPropertyName("mode")]
    public string? mode { get; set; }

    [JsonPropertyName("realised_point")]
    public string? realised_point { get; set; }

    [JsonPropertyName("contract")]
    public string? contract { get; set; }

    [JsonPropertyName("entry_price")]
    public string? entry_price { get; set; }

    [JsonPropertyName("mark_price")]
    public string? mark_price { get; set; }

    [JsonPropertyName("history_point")]
    public string? history_point { get; set; }

    [JsonPropertyName("realised_pnl")]
    public string? realised_pnl { get; set; }

    [JsonPropertyName("close_order")]
    public object? close_order { get; set; }

    [JsonPropertyName("size")]
    public int size { get; set; }

    [JsonPropertyName("cross_leverage_limit")]
    public string? cross_leverage_limit { get; set; }

    [JsonPropertyName("pending_orders")]
    public int pending_orders { get; set; }

    [JsonPropertyName("adl_ranking")]
    public int adl_ranking { get; set; }

    [JsonPropertyName("maintenance_rate")]
    public string? maintenance_rate { get; set; }

    [JsonPropertyName("unrealised_pnl")]
    public string? unrealised_pnl { get; set; }

    [JsonPropertyName("pnl_pnl")]
    public string? pnl_pnl { get; set; }

    [JsonPropertyName("pnl_fee")]
    public string? pnl_fee { get; set; }

    [JsonPropertyName("pnl_fund")]
    public string? pnl_fund { get; set; }

    [JsonPropertyName("user")]
    public long user { get; set; }

    [JsonPropertyName("leverage_max")]
    public string? leverage_max { get; set; }

    [JsonPropertyName("history_pnl")]
    public string? history_pnl { get; set; }

    [JsonPropertyName("risk_limit")]
    public string? risk_limit { get; set; }

    [JsonPropertyName("margin")]
    public string? margin { get; set; }

    [JsonPropertyName("last_close_pnl")]
    public string? last_close_pnl { get; set; }

    [JsonPropertyName("liq_price")]
    public string? liq_price { get; set; }

    [JsonPropertyName("update_time")]
    public long update_time { get; set; }

    [JsonPropertyName("update_id")]
    public long update_id { get; set; }

    [JsonPropertyName("initial_margin")]
    public string? initial_margin { get; set; }

    [JsonPropertyName("maintenance_margin")]
    public string? maintenance_margin { get; set; }

    [JsonPropertyName("trade_long_size")]
    public int trade_long_size { get; set; }

    [JsonPropertyName("trade_short_size")]
    public int trade_short_size { get; set; }

    [JsonPropertyName("open_time")]
    public long open_time { get; set; }

    [JsonPropertyName("risk_limit_table")]
    public string? risk_limit_table { get; set; }

    [JsonPropertyName("average_maintenance_rate")]
    public string? average_maintenance_rate { get; set; }

    [JsonPropertyName("voucher_size")]
    public string? voucher_size { get; set; }

    [JsonPropertyName("voucher_margin")]
    public string? voucher_margin { get; set; }

    [JsonPropertyName("voucher_id")]
    public long voucher_id { get; set; }

    [JsonPropertyName("pos_margin_mode")]
    public string? pos_margin_mode { get; set; }

    [JsonPropertyName("lever")]
    public string? lever { get; set; }
}
