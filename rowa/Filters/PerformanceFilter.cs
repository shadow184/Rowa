﻿using rowa.repository.Entities;
using rowa.repository.Interfaces;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace rowa.Filters
{
    public class PerformanceFilter : ActionFilterAttribute
    {
        private readonly Stopwatch _stopWatch;
        private readonly IPerformanceLogRepository _performanceLogRepository;

        public PerformanceFilter(IPerformanceLogRepository performanceLogRepository)
        {
            _performanceLogRepository = performanceLogRepository;
            _stopWatch = new Stopwatch();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _stopWatch.Start();

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _stopWatch.Stop();

            var time = _stopWatch.Elapsed.TotalMilliseconds;

            var performance = new PerformanceLog
            {
                ServerName = Environment.MachineName,
                Uri = filterContext.HttpContext.Request.Url.ToString(),
                Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Method = filterContext.ActionDescriptor.ActionName,
                ExecutionTime = time,
                RequestDate = DateTime.Now,
                IpAddress = GetIpAddress(filterContext)
            };

            _performanceLogRepository.Add(performance);

            base.OnActionExecuted(filterContext);
        }

        private string GetIpAddress(ActionExecutedContext filterContext)
        {
            var ip = filterContext.HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (ip != null)
            {
                return ip;
            }

            return filterContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}