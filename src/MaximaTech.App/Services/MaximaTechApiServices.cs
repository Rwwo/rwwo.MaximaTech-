﻿using MaximaTech.api.Models;
using MaximaTech.Application.Command;

using Newtonsoft.Json;

using RestSharp;


namespace MaximaTech.App.Services
{
    public class MaximaTechApiServices
    {
        private readonly string _urlBase;
        private readonly string _token;

        public MaximaTechApiServices(string token, bool desenvolvedor = true)
        {
            _token = token;
            _urlBase = desenvolvedor ? Constants.URL_BASE_HOMOLOGACAO : Constants.URL_BASE_PRODUCAO;
        }

        public GenericResult<List<Departamentos>> ConsultarDepartamentos()
        {
            var result = new GenericResult<List<Departamentos>>();
            try
            {
                var url = _urlBase + Constants.URL_DEPARTAMENTOS;

                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");

                var response = client.Execute(request);

                ProcessarResposta(response, result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<List<Produtos>> ConsultarProdutos()
        {
            var result = new GenericResult<List<Produtos>>();
            try
            {
                var url = _urlBase + Constants.URL_PRODUTOS;

                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");

                var response = client.Execute(request);

                ProcessarResposta(response, result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<Produtos> ConsultarProdutoDetalhes(Guid id)
        {
            var result = new GenericResult<Produtos>();
            try
            {
                var url = $"{_urlBase}{Constants.URL_PRODUTOS}/{id}{Constants.URL_PRODUTOS_DETALHES}";

                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");

                var response = client.Execute(request);

                ProcessarResposta(response, result);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public string AdicionarProduto(ProdutoViewModel produtoViewModel)
        {
            var result = "";
            try
            {
                var url = _urlBase + Constants.URL_PRODUTOS;

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");

                var modelSerialized = JsonConvert.SerializeObject(produtoViewModel);

                request.AddParameter("application/json", modelSerialized, ParameterType.RequestBody);

                var response = client.Execute(request);
                result = ProcessarResposta(response);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public string AtualizarProduto(EditarProdutoCommand editarProdutoCommand)
        {
            var result = "";
            try
            {
                var url = $"{_urlBase}{Constants.URL_PRODUTOS}";

                var client = new RestClient(url);
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");

                var modelSerialized = JsonConvert.SerializeObject(editarProdutoCommand);

                request.AddParameter("application/json", modelSerialized, ParameterType.RequestBody);

                var response = client.Execute(request);
                result = ProcessarResposta(response);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public string DeletarProduto(Guid id)
        {
            var result = "";
            try
            {
                var url = $"{_urlBase}{Constants.URL_PRODUTOS}/{id}/Deletar";

                var client = new RestClient(url);
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");

                var response = client.Execute(request);
                result = ProcessarResposta(response);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public GenericResult<string> Registrar(RegisterUserViewModel registerUserViewModel)
        {
            var result = new GenericResult<string>();
            try
            {
                var url = _urlBase + Constants.URL_CONTA_REGISTRO;

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                var modelSerialized = JsonConvert.SerializeObject(registerUserViewModel);

                request.AddParameter("application/json", modelSerialized, ParameterType.RequestBody);

                var response = client.Execute(request);
                result.Result = ProcessarResposta(response);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<string> Login(LoginUserViewModel loginUserViewModel)
        {
            var result = new GenericResult<string>();

            try
            {
                var url = _urlBase + Constants.URL_CONTA_LOGIN;

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                var modelSerialized = JsonConvert.SerializeObject(loginUserViewModel);

                request.AddParameter("application/json", modelSerialized, ParameterType.RequestBody);

                var response = client.Execute(request);
                result.Result = ProcessarResposta(response);
                result.StatusCode = response.StatusCode;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        private void ProcessarResposta<T>(IRestResponse response, GenericResult<T> result)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result.Result = JsonConvert.DeserializeObject<T>(response.Content);
                result.StatusCode = response.StatusCode;

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Success = true;
                }
                else
                {
                    //foreach (var erro in result.Result)
                    //    result.Message += $" {erro.Codigo} * {erro.Descricao}";
                }
            }
            else
            {
                result.Message = response.StatusDescription + $" {response.Content}";
            }

            result.StatusCode = response.StatusCode;
            result.Json = response.Content;
        }

        private string ProcessarResposta(IRestResponse response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Content;
            }

            return response.StatusDescription + $" {response.Content}";
        }
    }


    /*
    public class MaximaTechApiServices
    {
        private string _urlBase;
        private string? _token;
        public MaximaTechApiServices(string? token, bool desenvolvedor = true)
        {
            _token = token;
            _urlBase = desenvolvedor ? Constants.URL_BASE_HOMOLOGACAO : Constants.URL_BASE_PRODUCAO;
        }

        public GenericResult<List<Departamentos>> ConsultarDepartamentos()
        {
            var result = new GenericResult<List<Departamentos>>();
            try
            {

                var url = _urlBase + Constants.URL_DEPARTAMENTOS;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(RestSharp.Method.GET);

                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");


                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<Departamentos>>(response.Content);
                    result.StatusCode = response.StatusCode;

                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        foreach (var erro in result.Result)
                            result.Message += $" {erro.Codigo} * {erro.Descricao}";
                    }
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<List<Produtos>> ConsultarProdutos()
        {
            var result = new GenericResult<List<Produtos>>();
            try
            {

                var url = _urlBase + Constants.URL_PRODUTOS;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(RestSharp.Method.GET);

                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");


                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<List<Produtos>>(response.Content);
                    result.StatusCode = response.StatusCode;

                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        result.Success = true;
                    }
                    else
                    {
                        foreach (var erro in result.Result)
                            result.Message += $" {erro.Codigo} * {erro.Descricao}";
                    }
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public GenericResult<Produtos> ConsultarProdutosDetalhes(Guid Id)
        {
            var result = new GenericResult<Produtos>();
            try
            {

                var url = _urlBase + Constants.URL_PRODUTOS + $"/{Id}" + Constants.URL_PRODUTOS_DETALHES;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(RestSharp.Method.GET);

                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");


                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = JsonConvert.DeserializeObject<Produtos>(response.Content);
                    result.StatusCode = response.StatusCode;

                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        result.Success = true;
                    }
                }
                else
                {
                    result.Message = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public string AdicionarProduto(ProdutoViewModel produtoViewModel)
        {
            var result = "";
            try
            {
                var url = _urlBase + Constants.URL_PRODUTOS;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", $"Bearer {_token}");
                request.AddHeader("Content-Type", "application/json");

                var modelSerialized = JsonConvert.SerializeObject(produtoViewModel);

                request.AddParameter("application/json", modelSerialized, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result = response.Content;
                }
                else
                {
                    result = response.StatusDescription + $" {response.Content}";
                }

                //result.StatusCode = response.StatusCode;
                //result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return result;
        }

        public GenericResult<string> Registrar(RegisterUserViewModel registerUserViewModel)
        {
            var result = new GenericResult<string>();
            try
            {
                var url = _urlBase + Constants.URL_CONTA_REGISTRO;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                var modelSerialized = JsonConvert.SerializeObject(registerUserViewModel);

                request.AddParameter("application/json", modelSerialized, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = response.Content;


                }
                else
                {
                    result.Result = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Result = ex.Message;
            }

            return result;
        }

        public GenericResult<string> Login(LoginUserViewModel loginUserViewModel)
        {
            var result = new GenericResult<string>();

            try
            {
                var url = _urlBase + Constants.URL_CONTA_LOGIN;

                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                var modelSerialized = JsonConvert.SerializeObject(loginUserViewModel);

                request.AddParameter("application/json", modelSerialized, ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Result = response.Content;

                }
                else
                {
                    result.Result = response.StatusDescription + $" {response.Content}";
                }

                result.StatusCode = response.StatusCode;
                result.Json = response.Content;
            }
            catch (Exception ex)
            {
                result.Result = ex.Message;
            }

            return result;
        }
    }
    */
}
