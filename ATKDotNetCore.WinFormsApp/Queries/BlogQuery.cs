namespace ATKDotNetCore.WinFormsApp.Queries;

internal class BlogQuery
{
    public static string BlogCreateQuery = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";
}
