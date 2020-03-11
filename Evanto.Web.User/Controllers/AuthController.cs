using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Evanto.Web.User.Attributes;
using Evanto.Web.User.Constants;
using Evanto.Web.User.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Evanto.Web.User.Controllers
{
  [EnableCors("*", "*", "*")]
  public class AuthController : Controller
  {
    [Route("~/authentication/login")]
    [HttpPost]
    public async Task<JsonResult> Login(Models.User user)
    {
      if (!string.IsNullOrEmpty(user.UserName) & !string.IsNullOrEmpty(user.Password))
      {
        using (HttpClient client = new HttpClient())
        {
          client.BaseAddress = new Uri(AuthServer.BaseAddress);
          client.DefaultRequestHeaders.Accept.Clear();
          client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

          var content = new FormUrlEncodedContent(new[]
           {
                new KeyValuePair<string, string>(AuthValues.Username, user.UserName),
                new KeyValuePair<string, string>(AuthValues.Password, user.Password),
                new KeyValuePair<string, string>(AuthValues.GrantType, nameof(user.Password).ToLower()),
                new KeyValuePair<string, string>(AuthValues.ClientId, ClientInfo.ClientId),
                new KeyValuePair<string, string>(AuthValues.ClientSecret, ClientInfo.ClientSecret)
            });
          var response = await client.PostAsync(AuthServer.TokenUrl, content);
          if (response.IsSuccessStatusCode)
          {
            Session["IsAuthorized"] = true;

            var data = await response.Content.ReadAsAsync<Dictionary<string, string>>();
            return new JsonResult
            {
              Data = data.Select(d => new
              {
                access_token = d.Value
              }).First()
            };
          }
          else
          {
            Session["IsAuthorized"] = false;

            dynamic result = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

            return new JsonResult
            {
              Data = new
              {
                  errorList = data
              }
            };

          }
        }
      }
      return null;
    }

    [Route("~/authentication/logout")]
    [HttpPost]
    public void LogOut()
    {
      Session["IsAuthorized"] = false;
    }
  }
}
