using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using socialpostanalyzer.DBContext;
using socialpostanalyzer.Models;
using System.Diagnostics;
namespace socialpostanalyzer.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<PageController> _logger;
        private readonly SocialDbContext _context;

        public PageController(ILogger<PageController> logger, SocialDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpPost]

        public IActionResult SavePage([FromBody] SavePublicPagesRequest request)
        {
            try
            {
                string name = request.Name;
                List<SelectedPublicPage> SelectedPublicPages = request.SelectedPublicPages;
                int userId = _context.Users.FirstOrDefault(u => u.UserName == name)?.UserId ?? 0;

                if (userId == 0)
                {
                    return BadRequest("User not found in the database.");
                }
                var idPage = _context.Pages.FirstOrDefault(p => p.PageId == request.PageId)?.id;
                if (idPage == null)
                {
                    var page = new Page
                    {
                        PageId = request.PageId,
                        PageName = request.PageName,
                        Token = "public",
                        type = "public"
                    };

                    _context.Pages.Add(page);
                    _context.SaveChanges();

                    var Pageid = _context.Pages.FirstOrDefault(p => p.PageId == request.PageId)?.id;

                    var userPage = new UserPages
                    {
                        UserId = userId,
                        id = Pageid.Value
                    };

                    _context.UserPages.Add(userPage);
                    _context.SaveChanges();
                }
                var Pageidd = _context.Pages.FirstOrDefault(p => p.PageId == request.PageId)?.id;

                foreach (var selectedPage in SelectedPublicPages)
                {

                    var post = new Post
                        {
                            PostId = selectedPage.PostId,
                            ImgAdress =selectedPage.ImgAdress,
                            Description=selectedPage.Description,
                            LikesNum= selectedPage.LikesNum,
                            LoveNum=selectedPage.LoveNum,
                            WowNum= selectedPage.WowNum,
                            SadNum= selectedPage.SadNum,
                            AngryNum= selectedPage.AngryNum,
                            HahaNum= selectedPage.HahaNum,
                            SharesNum= selectedPage.SharesNum,
                            CommentsNum= selectedPage.CommentsNum,
                            CreatedAt=selectedPage.CreatedAt,
                            PageId=(int)Pageidd,

                        };
                        _context.Post.Add(post);
                        _context.SaveChanges();

                    foreach (var commentData in selectedPage.comment)
                    {
                        var comment = new Comment
                        {
                          
                            Text = commentData.Text,
                            CreatedAt = commentData.CommentCreatedAt,
                            post = post,

                        };
                        _context.Comment.Add(comment);
                        _context.SaveChanges();

                        var reaction = new Reaction
                        {
                            Like = commentData.Reactions.Like,
                            Love= commentData.Reactions.Love,
                            Wow= commentData.Reactions.Wow,
                            Sad= commentData.Reactions.Sad,
                            Angry= commentData.Reactions.Angry,
                            Haha= commentData.Reactions.Haha,
                            post=post,
                        };
                        _context.Reaction.Add(reaction);
                        _context.SaveChanges();
                    }
                }

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to save selected pages: " + ex.Message + " Inner Exception: " + ex.InnerException?.Message);
            }
        }



        [HttpGet("/Page/getSavedPublicPages")]
        public IActionResult getSavedPublicPages([FromQuery] string userName)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

                if (user == null)
                {
                    return BadRequest("User not found in the database.");
                }

                int userId = user.UserId;

                // Retrieve the saved pages for the given userId from the database
                var savedPublicPages = _context.Pages
                    .Join(_context.UserPages, p => p.id, up => up.id, (p, up) => new { Page = p, UserPage = up })
                    .Where(j => j.UserPage.UserId == userId && j.Page.type == "public")
                    .Select(j => new SelectedPage
                    {
                        PageId = j.Page.PageId,
                        PageName = j.Page.PageName,
                        accessToken = j.Page.Token,

                    })
                    .ToList();

                return Ok(savedPublicPages);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve saved pages: " + ex.Message);
            }
        }


        [HttpDelete("/Page/DeletePage")]
        public IActionResult DeletePage([FromQuery] string pageName)
        {
            try
            {
                var pageToDelete = _context.Pages.FirstOrDefault(p => p.PageName == pageName);

                if (pageToDelete == null)
                {
                    return NotFound("Page not found.");
                }
                var postsToDelete = _context.Post.Where(p => p.PageId == pageToDelete.id).ToList();

                foreach (var post in postsToDelete)
                {
                    var reactionsToDelete = _context.Reaction.Where(r => r.post.PageId == pageToDelete.id).ToList();
                    var commentsToDelete = _context.Comment.Where(c => c.post.PageId == pageToDelete.id).ToList();


                    _context.Reaction.RemoveRange(reactionsToDelete);
                    _context.Comment.RemoveRange(commentsToDelete);

                    _context.Post.Remove(post);
                }

                _context.Pages.Remove(pageToDelete);
                _context.SaveChanges();

                return Ok("Page deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete page: " + ex.Message);
            }
        }


    }
}


