using System;
namespace DemoWebApi.Models
{
	public class ResponseEntity
	{
		public string ErrCode { set; get; } = "00000";
		public string ErrMessage { set; get; } = "Success";
		public object Data { set; get; } = null!;
	}
}

