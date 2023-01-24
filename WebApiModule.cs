using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace WebAPI.OWIN
{
    public class WebApiModule
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        public WebApiModule(Func<IDictionary<string, object>, Task> next)
        {
            if (next == null)
                throw new ArgumentNullException("next");
            
            this._next = next;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            try
            {
                var request = new OwinRequest(env);
                var path = request.Path.Value.TrimEnd(new [] { '/' });

                if (path.Equals("/CurrentTimeOwinModule", StringComparison.OrdinalIgnoreCase))
                {
                    var response = new OwinResponse(env);
                    return response.WriteAsync(DateTime.Now.ToString());
                }
            }
            catch (Exception e)
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(e);
                return tcs.Task;
            }

            return this._next(env);
        }
    }
}