using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAssignments
{
    // --- PART 1: NOTIFICATION SERVICES ---
    public interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Email sent to {recipient}: {message}");
        }
    }

    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"SMS sent to {recipient}: {message}");
        }
    }

    public class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.WriteLine($"Push Notification sent to {recipient}: {message}");
        }
    }

    // --- PART 2: SHAPE HIERARCHY ---
    public interface IShape
    {
        double Area { get; }
        void DisplayShapeInfo();
    }

    public interface ICircle : IShape
    {
        double Radius { get; set; }
    }

    public interface IRectangle : IShape
    {
        double Width { get; set; }
        double Height { get; set; }
    }

    public class Circle : ICircle
    {
        public double Radius { get; set; }
        public double Area => Math.PI * Math.Pow(Radius, 2);

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Circle - Radius: {Radius}, Area: {Area:F2}");
        }
    }

    public class Rectangle : IRectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area => Width * Height;

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Rectangle - Width: {Width}, Height: {Height}, Area: {Area:F2}");
        }
    }

    // --- PART 3: AUTHENTICATION SERVICE ---
    public interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);
        bool AuthorizeUser(string username, string role);
    }

    public class BasicAuthenticationService : IAuthenticationService
    {
        private readonly string _storedUser = "admin";
        private readonly string _storedPass = "1234";
        private readonly string _storedRole = "Manager";

        public bool AuthenticateUser(string username, string password)
        {
            return username == _storedUser && password == _storedPass;
        }

        public bool AuthorizeUser(string username, string role)
        {
            return username == _storedUser && role == _storedRole;
        }
    }

    // --- MAIN EXECUTION CLASS ---
    class Task3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 1. Notification Services ===");
            INotificationService email = new EmailNotificationService();
            email.SendNotification("user@test.com", "Welcome to C#!");

            Console.WriteLine("\n=== 2. Shape Implementation ===");
            Circle myCircle = new Circle { Radius = 5 };
            Rectangle myRect = new Rectangle { Width = 10, Height = 5 };
            myCircle.DisplayShapeInfo();
            myRect.DisplayShapeInfo();

            Console.WriteLine("\n=== 3. Authentication Service ===");
            IAuthenticationService auth = new BasicAuthenticationService();
            if (auth.AuthenticateUser("admin", "1234"))
            {
                Console.WriteLine("Login Successful.");
                Console.WriteLine("Authorized for Manager: " + auth.AuthorizeUser("admin", "Manager"));
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }

    /*
    QUIZ ANSWERS:
    Question 1: b) To define a blueprint for a class
    Question 2: a) private
    Question 3: b) No
    Question 4: b) Yes, interfaces can inherit from multiple interfaces
    Question 5: d) None (C# uses the ':' symbol)
    Question 6: a) Yes
    Question 7: b) No, all members are implicitly public
    Question 8: b) To provide a clear separation between interface and class members
    Question 9: b) No, interfaces cannot have constructors
    Question 10: c) By separating interface names with commas
    */
}