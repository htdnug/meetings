using System;
using System.Linq;

namespace AuditingEntityFramework
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var widget = new Widget
                {
                    Name = $"Widget Name {DateTime.Now}"
                };

                using (var context = new TestDbContext())
                {
                    context.Widgets.Add(widget);
                    context.SaveChanges();

                    var otherWidget = context.Widgets.SingleOrDefault(x => x.Id == widget.Id);
                    otherWidget.Name = $"Widget Name Changed {DateTime.Now}";
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
