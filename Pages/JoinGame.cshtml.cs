using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Timmy.Models;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;



namespace Timmy.Pages
{

    public class JoinGame : PageModel
    {


        private readonly IConfiguration Configuration;
        //public PositionOptions positionOptions { get; private set; }

        public JoinGame(IConfiguration configuration)
        {
                Configuration = configuration;
        }


        [BindProperty]
        public PlayerModel Player { get; set; }

        [BindProperty]
        public bool IsDrawing { get; set; }


        public void OnGet()
        {
            //run this code when page is displayed
            
        }

        public IActionResult OnPost()
        {
            if  (ModelState.IsValid == false)
            {
                 return Page();
            }

            if (IsDrawing)
            {
                Player.PlayerType = true;
            } else
            {
                Player.PlayerType = false;
            }

           // add player to DB 
           
            var builder = new SqlConnectionStringBuilder(
                Configuration["ConnectionStrings:defaultConnection"]);
                builder.Password = Configuration["C19GameNightKey"];
              
                var bobo = builder.ConnectionString;
            
            SqlConnection PlayerConn = new SqlConnection(builder.ConnectionString); 
            PlayerConn.Open();

            

            //insert new player
            
            string SQLValues = "N'" + @Player.PlayerName + "', '" + @Player.GameID + "', '" + @Player.PlayerType + "'";
            var sql = "INSERT INTO Players ([PlayerName], [GameID], [PlayerType]) VALUES (" + SQLValues + ");";            
            
            // INSERT INTO Players ([PlayerName], [GameID], [PlayerType]) VALUES ( N'Frances', 'ABCDE', 1);            

            var command = new SqlCommand(sql, PlayerConn);
            int rowsAffected = command.ExecuteNonQuery();                       
            
            //get new count of total players            
            command.CommandText = "SELECT COUNT(*) FROM dbo.players; ";
            rowsAffected = (Int32) command.ExecuteScalar();
            
            PlayerConn.Close();            

            return RedirectToPage("./Index", new{PageUser = Player.PlayerName + " = " + rowsAffected.ToString()});

        }

        

    
        
    }
}