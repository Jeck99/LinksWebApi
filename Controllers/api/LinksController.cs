using LinksWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LinksWebApplication.Controllers.api
{
    public class LinksController : ApiController
    {
        MyDBContext m_db = new MyDBContext();

        // /api/Links
        [HttpGet]
        public IEnumerable<Link> GetLinks()
        {
            return m_db.Links;
        }
        // GET /api/Links/1
        [HttpGet]
        public IHttpActionResult GetLink(long id)
        {
            Link Link = m_db.Links.Find(id);
            if (Link == null)
            {
                return NotFound();
            }
            return Ok(Link);
        }
        // POST /api/Links
        [HttpPost]
        public IHttpActionResult CreateLink(Link link)
        {
            if ((link != null) && !validationIsOk(link.src, link.Category))
            {
                return BadRequest();
            }
            m_db.Links.Add(link);
            m_db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = link.Id }, link);
        }

        // PUT /api/Links/4 -> update Link with id 4
        [HttpPut]
        public IHttpActionResult UpdateLink(int id, Link link)
        {
            if ((link != null) && !validationIsOk(link.src, link.Category)) { return BadRequest(); }
            if (id != link.Id) { return BadRequest(); }
            Link updatedLink = m_db.Links.Find(link.Id);
            if (updatedLink == null) { return NotFound(); }
            updatedLink.src = link.src;
            updatedLink.UserId = link.UserId;
            updatedLink.Category = link.Category;
            m_db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
        // DELETE /api/Links/4 -> delete Link with id 4
        [HttpDelete]
        public IHttpActionResult DeleteLink(int id)
        {
            Link link = m_db.Links.Find(id);
            if (link == null)
            {
                return NotFound();
            }
            m_db.Links.Remove(link);
            m_db.SaveChanges();
            return Ok(link);
        }
        private bool validationIsOk(string linkUrl, string category)
        {
            return !string.IsNullOrEmpty(linkUrl) || !string.IsNullOrEmpty(category);
        }
        // GET /api/UserLinks/1
        [Route("api/UserLinks")]
        [HttpGet]
        public async Task<IHttpActionResult> GetLinksByUserId(long userId)
        {
            List<Link> links = new List<Link>();
            foreach (var item in m_db.Links)
            {
                if (item.UserId == userId)
                {
                    links.Add(item);
                }
            }
            if (links == null)
            {
                return NotFound();
            }

            return Ok(links);
        }
    }
}

