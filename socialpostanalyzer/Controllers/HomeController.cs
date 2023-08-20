using Microsoft.AspNetCore.Mvc;
using socialpostanalyzer.Models;
using socialpostanalyzer.DBContext;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace socialpostanalyzer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SocialDbContext _context;

        public HomeController(ILogger<HomeController> logger, SocialDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var user = new User()
            {
                UserName = model.Username,
                Password = model.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == model.Username && u.Password == model.Password);

            if (user != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }

        [HttpPost]
        public IActionResult SaveSelectedPages([FromBody] SaveSelectedPagesRequest request)
        {
            try
            {
                string name = request.Name;
                List<SelectedPage> selectedPages = request.SelectedPages;
                int userId = _context.Users.FirstOrDefault(u => u.UserName == name)?.UserId ?? 0;
                
                if (userId == 0)
                {
                    return BadRequest("User not found in the database.");
                }

                foreach (var selectedPage in selectedPages)
                {
                    var page = new Page
                    {
                        PageId = selectedPage.PageId,
                        PageName = selectedPage.PageName,
                        Token = selectedPage.accessToken,
                        type= "private"
                    };

                    _context.Pages.Add(page);
                    _context.SaveChanges();
                    var idPage = _context.Pages.FirstOrDefault(p => p.PageId == selectedPage.PageId)?.id;

                    if (idPage != 0)
                    {
                        var userPage = new UserPages
                        {
                            UserId = userId,
                            id = idPage.Value
                        };

                        _context.UserPages.Add(userPage);
                        _context.SaveChanges();
                    }
                }
               

                foreach (var selectedPage in selectedPages)
                {
                    var Pageidd = _context.Pages.FirstOrDefault(p => p.PageId == selectedPage.PageId)?.id;
                    foreach (var feed in selectedPage.feedData.data)
                    {
                        var post = new Post
                        {
                            Description = feed.message ?? "null",
                            CreatedAt=DateTime.Parse(feed.created_time),
                            CommentsNum=feed.comments.Summary.total_count,
                            LikesNum=feed.like.summary.total_count,
                            AngryNum=feed.angry.summary.total_count,
                            HahaNum=feed.haha.summary.total_count,
                            LoveNum=feed.love.summary.total_count,
                            SadNum=feed.sad.summary.total_count,
                            WowNum=feed.wow.summary.total_count,
                            PostId=feed.id.ToString(),
                            ImgAdress=feed.full_picture ?? "null",
                            PageId = (int)Pageidd,
                        };
                        _context.Post.Add(post);
                        _context.SaveChanges();
                        var reaction = new Reaction
                        {
                            Like = feed.like.summary.total_count,
                            Love = feed.love.summary.total_count,
                            Wow = feed.wow.summary.total_count,
                            Sad = feed.sad.summary.total_count,
                            Angry = feed.angry.summary.total_count,
                            Haha = feed.haha.summary.total_count,
                            post = post,
                        };
                        _context.Reaction.Add(reaction);
                        _context.SaveChanges();
                        foreach (var commentData in feed.comments.Data)
                        {
                            var comment = new Comment
                            {

                                Text = commentData.message,
                                CreatedAt=commentData.created_time,
                                post = post,

                            };
                            _context.Comment.Add(comment);
                            _context.SaveChanges();

                            
                        }
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


       

        [HttpGet("/Home/getSavedPages")]
        public IActionResult GetSavedPages([FromQuery] string userName)
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
                var savedPages = _context.Pages
                    .Join(_context.UserPages, p => p.id, up => up.id, (p, up) => new { Page = p, UserPage = up })
                    .Where(j => j.UserPage.UserId == userId && j.Page.type == "private")
                    .Select(j => new SelectedPage
                    {
                        PageId = j.Page.PageId,
                        PageName = j.Page.PageName,
                        accessToken = j.Page.Token,
                      
                    })
                    .ToList();

                return Ok(savedPages);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve saved pages: " + ex.Message);
            }
        }



        [HttpGet("/Home/getAllSavedPages")]
        public IActionResult GetAllSavedPages([FromQuery] string userName)
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
                var savedPages = _context.Pages
                    .Join(_context.UserPages, p => p.id, up => up.id, (p, up) => new { Page = p, UserPage = up })
                    .Where(j => j.UserPage.UserId == userId )
                    .Select(j => new SelectedPage
                    {
                        PageId = j.Page.PageId,
                        PageName = j.Page.PageName,
                        accessToken = j.Page.Token,

                    })
                    .ToList();

                return Ok(savedPages);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve saved pages: " + ex.Message);
            }
        }

        [HttpGet("/Home/GetAccessToken")]
        public IActionResult GetAccessToken(string pageName)
        {
            try
            {
                var page = _context.Pages.FirstOrDefault(p => p.PageName == pageName);

                if (page == null)
                {
                    return NotFound();
                }

                var accessToken = page.Token;
                return Ok(accessToken);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve access token: " + ex.Message);
            }
        }


        [HttpGet("/Home/getPageData")]
        public async Task<IActionResult> GetPageData(string pageId)
        {
            try
            {
                var pageData = await _context.Pages.FirstOrDefaultAsync(p => p.PageId == pageId);

                if (pageData == null)
                {
                    return NotFound("Page data not found");
                }

                int idpage = pageData.id;

                var posts = await _context.Post.Where(p => p.PageId == idpage).ToListAsync();
                List<List<Reaction>> postReactionsList = new List<List<Reaction>>();

                foreach (var post in posts)
                {
                    string postId = post.PostId;

                    // Get comments with matching PostId
                    var comments = await _context.Comment.Where(c => c.post.PostId == postId).ToListAsync();
                    post.comments = comments;

                    // Get reactions with matching PostId
                    var reactions = await _context.Reaction.Where(r => r.post.PostId == postId).ToListAsync();
                    postReactionsList.Add(reactions);
                }

                var responseData = new
                {
                    pageData.PageId,
                    pageData.PageName,
                    pageData.CreatedAt,
                    posts,
                    postReactionsList,
                };

                var jsonOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve, // Add this line to handle object cycles
                    WriteIndented = true // Optional: Format the JSON for better readability during debugging
                };

                var json = JsonSerializer.Serialize(responseData, jsonOptions);

                return Content(json, "application/json");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to retrieve page data: " + ex.Message);
            }
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}