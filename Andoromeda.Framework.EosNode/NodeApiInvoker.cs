using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;

namespace Andoromeda.Framework.EosNode
{
    public class NodeApiInvoker : IDisposable
    {
        private INodeProvider _nodeProvider;
        private HttpClient _client;

        public NodeApiInvoker(INodeProvider nodeProvider)
        {
            this._nodeProvider = nodeProvider;
            this._client = new HttpClient { BaseAddress = new Uri(_nodeProvider.GetNodes().First()) };
        }

        public void Dispose()
        {
            _client?.Dispose();
        }

        public async Task<GetActionsResponse> GetActionsAsync(string account, int skip = 0, int take = 100, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.PostAsync("/v1/history/get_actions", new StringContent(JsonConvert.SerializeObject(new
            {
                account_name = account,
                pos = skip,
                offset = take - 1
            }), Encoding.UTF8, "application/json"), cancellationToken))
            {
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetActionsResponse>(responseText);
            }
        }

        public async Task<GetTableByScopeResponse> GetTableByScopeAsync(string code, string table, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.PostAsync("/v1/chain/get_table_by_scope", new StringContent(JsonConvert.SerializeObject(new
            {
                code = code,
                table = table,
                json = true
            }), Encoding.UTF8, "application/json"), cancellationToken))
            {
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetTableByScopeResponse>(responseText);
            }
        }

        public async Task<GetTableRowsResponse<T>> GetTableRowsAsync<T>(string code, string table, string scope, int skip = 0, int take = 100, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.PostAsync("/v1/chain/get_table_rows", new StringContent(JsonConvert.SerializeObject(new
            {
                code = code,
                table = table,
                scope = scope,
                json = true,
                pos = skip,
                offset = take - 1
            }), Encoding.UTF8, "application/json"), cancellationToken))
            {
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetTableRowsResponse<T>>(responseText);
            }
        }

        public async Task<double> GetCurrencyBalanceAsync(string account, string code, string symbol, CancellationToken cancellationToken = default)
        {
            symbol = symbol.ToUpper();

            using (var response = await _client.PostAsync("/v1/chain/get_currency_balance", new StringContent(JsonConvert.SerializeObject(new
            {
                code = code,
                symbol = symbol,
                account = account
            }), Encoding.UTF8, "application/json"), cancellationToken))
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<string>>(responseText);

                if (result.Count() == 0)
                {
                    return 0;
                }

                var ret = result.FirstOrDefault(x => x.EndsWith(" " + symbol));
                if (ret == null)
                {
                    return 0;
                }

                return Convert.ToDouble(ret.Split(' ')[0]);
            }
        }

        public async Task<GetCurrencyBalanceResponse> GetCurrencyBalanceAsync(string account, string code, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.PostAsync("/v1/chain/get_table_rows", new StringContent(JsonConvert.SerializeObject(new
            {
                code = code,
                json = true,
                account = account
            }), Encoding.UTF8, "application/json"), cancellationToken))
            {
                var responseText = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<string>>(responseText);
                var ret = new List<GetCurrencyBalanceResponseRow>(result.Count());
                foreach (var x in result)
                {
                    var splited = x.Split(' ');
                    ret.Add(new GetCurrencyBalanceResponseRow
                    {
                        amount = Convert.ToDouble(splited[0]),
                        symbol = splited[1]
                    });
                }

                return new GetCurrencyBalanceResponse
                {
                    balances = ret
                };
            }
        }

        public async Task<GetAccountResponse> GetAccountAsync(string account, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.PostAsync("/v1/chain/get_account", new StringContent(JsonConvert.SerializeObject(new
            {
                account_name = account
            }), Encoding.UTF8, "application/json"), cancellationToken))
            {
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetAccountResponse>(responseText);
            }
        }

        public async Task<GetAbiJsonToBinResponse> GetAbiJsonToBinAsync(string code, string action, object data, CancellationToken cancellationToken = default)
        {
            using (var response = await _client.PostAsync("/v1/chain/abi_json_to_bin", new StringContent(JsonConvert.SerializeObject(new
            {
                code = code,
                action = action,
                args = data
            }), Encoding.UTF8, "application/json"), cancellationToken))
            {
                var responseText = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<GetAbiJsonToBinResponse>(responseText);
            }
        }
    }
}
