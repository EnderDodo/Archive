// See https://aka.ms/new-console-template for more information
using LINQ;

int n = 100;
BusinessLogic a = new BusinessLogic(n);

List<User> surnamed = a.GetUsersBySurname("Александрийский");
a.WriteUsersData(surnamed);

surnamed = a.GetUsersBySurname("Андреев");
a.WriteUsersData(surnamed);
Console.WriteLine();

a.WriteUserData(a.GetUserByID(n - 8));
a.WriteUserData(a.GetUserByID(n + 8));

a.WriteUsersData(a.GetUsersBySubstring("андр"));
a.WriteUsersData(a.GetUsersBySubstring("87"));
a.WriteUsersData(a.GetUsersBySubstring("барр"));

a.GetAllUniqueNames().ForEach(name => Console.WriteLine(name));

a.WriteUsersData(a.GetAllAuthors());

a.WriteUsersData(a.GetUsersDictionary());

Console.WriteLine(a.GetMaxID());

a.WriteUsersData(a.GetOrderedUsers());

a.WriteUsersData(a.GetDescendingOrderedUsers());

a.WriteUsersData(a.GetReversedUsers());

a.WriteUsersData(a.GetUsersPage(0, 0));
a.WriteUsersData(a.GetUsersPage(10, 1));
a.WriteUsersData(a.GetUsersPage(10, 10));
a.WriteUsersData(a.GetUsersPage(11, 10));
