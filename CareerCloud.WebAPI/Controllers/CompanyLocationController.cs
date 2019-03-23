using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
	[RoutePrefix("api/careercloud/company/v1")]
    public class CompanyLocationController : ApiController
    {
		private CompanyLocationLogic _logic;

		public CompanyLocationController()
		{
			EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>(false);
			_logic = new CompanyLocationLogic(repo);
		}

		[Route("location/{companyLocationId}")]
		[HttpGet]
		[ResponseType(typeof(CompanyLocationPoco))]
		public IHttpActionResult GetCompanyLocation(Guid companyLocationId)
		{
			try
			{
				CompanyLocationPoco poco = _logic.Get(companyLocationId);
				if (poco == null)
				{
					return NotFound();
				}
				return Ok(poco);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpGet]
		[Route("location")]
		[ResponseType(typeof(List<CompanyLocationPoco>))]
		public IHttpActionResult GetAllCompanyLocation()
		{
			try
			{
				List<CompanyLocationPoco> pocos = _logic.GetAll();
				if (pocos == null)
				{
					return NotFound();
				}
				return Ok(pocos);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpPost]
		[Route("location")]
		[ResponseType(typeof(CompanyLocationPoco))]
		public IHttpActionResult PostCompanyLocation([FromBody]CompanyLocationPoco[] pocos)
		{
			try
			{
				_logic.Add(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpPut]
		[Route("location")]
		[ResponseType(typeof(CompanyLocationPoco))]
		public IHttpActionResult PutCompanyLocation([FromBody]CompanyLocationPoco[] pocos)
		{
			try
			{
				_logic.Update(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpDelete]
		[Route("location")]
		[ResponseType(typeof(CompanyLocationPoco))]
		public IHttpActionResult DeleteCompanyLocation([FromBody]CompanyLocationPoco[] pocos)
		{
			try
			{
				_logic.Delete(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}
    }
}
