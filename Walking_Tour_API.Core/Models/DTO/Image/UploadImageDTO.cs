using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking_Tour_API.Core.Models.DTO.Image
{
	public class UploadImageDTO
	{
		[Required]
		public IFormFile File { get; set; }

		[Required]
		public string FileName { get; set; }

		public string? FileDescription { get; set; }
	}
}
