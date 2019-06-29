using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcalligator.Helper
{
    public class CustomExceptionFilter:FilterAttribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                string controller = context.RouteData.Values["controller"].ToString();
                string action = context.RouteData.Values["action"].ToString();
                HandleErrorInfo boj = new HandleErrorInfo(context.Exception, controller, action);
                var view = new ViewResult();
                view.ViewName = "CustomError";
                view.ViewData = new ViewDataDictionary();
                view.ViewData.Model = boj;
                view.ExecuteResult(context);
               
                context.ExceptionHandled = true;
                
            }
        }
    }
}