Scaffolding has generated all the files and added the required dependencies.

However the Application's Startup code may required additional changes for things to work end to end.
Add the following code to the Configure method in your Application's Startup class if not already done:

       app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
		
		//DBContext update command
		Scaffold-DbContext "server=127.0.0.1;user id=root;pwd=1234;persistsecurityinfo=True;database=apiexcercise" MySql.EntityFrameworkCore -OutputDir Repositories/DAL/Models -f