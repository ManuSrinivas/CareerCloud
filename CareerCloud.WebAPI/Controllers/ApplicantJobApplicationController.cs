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
	[RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantJobApplicationController : ApiController
    {
		private ApplicantJobApplicationLogic _logic;

		public ApplicantJobApplicationController()
		{
			EFGenericRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
			_logic = new ApplicantJobApplicationLogic(repo);
		}

		[HttpGet]
		[Route("jobapplication/{applicantJobApplicationId}")]
		[ResponseType(typeof(ApplicantJobApplicationPoco))]
		public IHttpActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
		{
			try
			{
				ApplicantJobApplicationPoco poco = _logic.Get(applicantJobApplicationId);
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
		[Route("jobapplication")]
		[ResponseType(typeof(List<ApplicantJobApplicationPoco>))]
		public IHttpActionResult GetAllApplicantJobApplication()
		{
			try
			{
				List<ApplicantJobApplicationPoco> pocos = _logic.GetAll();
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
		[Route("jobapplication")]
		public IHttpActionResult PostApplicantJobApplication([FromBody]ApplicantJobApplicationPoco[] pocos)
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
		[Route("jobapplication")]
		public IHttpActionResult PutApplicantJobApplication([FromBody]ApplicantJobApplicationPoco[] pocos)
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
		[Route("jobapplication")]
		public IHttpActionResult DeleteApplicantJobApplication([FromBody]ApplicantJobApplicationPoco[] pocos)
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
