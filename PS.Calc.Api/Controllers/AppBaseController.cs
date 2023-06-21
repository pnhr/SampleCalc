﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Calc.Api.Util;
using PS.Calc.Data.Constants;

namespace PS.Calc.Api.Controllers
{
    [ApiController]
    public abstract class AppBaseController : ControllerBase
    {
        public AppBaseController(IConfiguration config, ILogger logger)
        {
            Configuration = config;
            Logger = logger;
        }
        public IConfiguration Configuration { get; set; }
        public ILogger Logger { get; set; }

        [NonAction]
        protected OkObjectResult OkWrapper<T>(bool isSuccess, string msg, T data) where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = isSuccess;
            response.Message = msg;
            response.Payload = data;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper(bool isSuccess, string msg)
        {
            ApiResponse<object> response = new ApiResponse<object>();
            response.IsSuccess = isSuccess;
            response.Message = msg;
            response.Payload = null;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper<T>(string msg, T data) where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = true;
            response.Message = msg;
            response.Payload = data;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper<T>(T data) where T : class
        {
            ApiResponse<T> response = new ApiResponse<T>();
            response.IsSuccess = true;
            response.Message = AppConstants.SUCCESS;
            response.Payload = data;
            return Ok(response);
        }
        [NonAction]
        protected OkObjectResult OkWrapper()
        {
            ApiResponse<object> response = new ApiResponse<object>();
            response.IsSuccess = true;
            response.Message = AppConstants.SUCCESS;
            response.Payload = null;
            return Ok(response);
        }
    }
}
