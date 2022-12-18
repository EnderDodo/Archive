using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ
{
    class BusinessLogic
    {
        private List<User> users = new List<User>();
        private List<Record> records = new List<Record>();
        public BusinessLogic(int n)
        {
            string[] names = new string[] { "Алексей", "Анатолий", "Андрей", "Александр", "Борис", "Богдан", "Валентин", "Василий", "Владимир" };
            string[] surnames = new string[] { "Алексеев", "Андреев", "Владимиров", "Солнцев", "Побединский", "Меладзе", "Канкумашев", "Трунов", "Назарец" };
            string[] messages = new string[] { "first commit", "GET DUNKED ON", "New brand new features are implemented!", "hemlo boss where", "haii lumch when" };


            Enumerable.Range(1, n).ToList().ForEach(
                i =>
            {
                User user = new(i, names[i % names.Length], surnames[i % surnames.Length]);
                Record record = new(user, messages[i % messages.Length]);

                users.Add(user);
                records.Add(record);
            });
        }
        public List<User> GetUsersBySurname(string surname)
        {

            List<User> selectedUsers = (from u in users where u.Surname == surname select u).ToList();
            return selectedUsers;
        }
        public User? GetUserByID(int id)
        {
            IEnumerable<User> usersFound = from u in users where u.ID == id select u;


            if (usersFound.Count() > 1)
            {
                Console.WriteLine($"Error: Multiple users with the same ID ({id})");
                return null;
            }
            else if (usersFound.Count() == 0)
            {
                Console.WriteLine($"Error: User wih corresponding ID ({id}) was not found");
                return null;
            }
            else
            {
                User selectedUser = usersFound.Single();
                return selectedUser;
            }


        }
        public List<User> GetUsersBySubstring(string substring)
        {
            List<User> usersFound = users.Where(u => u.Name.ToLower().Contains(substring.ToLower()) || u.Surname.ToLower().Contains(substring.ToLower()) || u.ID.ToString().Contains(substring)).ToList();
            return usersFound;
        }
        public List<string> GetAllUniqueNames()
        {
            List<string> namesFound = users.Select(u => u.Name).Distinct().ToList();
            return namesFound;
        }
        public List<User> GetAllAuthors()
        {
            List<User> authors = records.Join(users, r => r.Author, u => u, (r, u) => new User(u.ID, u.Name, u.Surname)).ToList();
            return authors;
        }
        public Dictionary<int, User> GetUsersDictionary()
        {
            Dictionary<int, User> usersDictionary = users.ToDictionary(u => u.ID, u => u);
            return usersDictionary;
        }
        public int GetMaxID()
        {
            int maxID = users.Max(u => u.ID);
            return maxID;
        }

        public List<User> GetOrderedUsers()
        {
            List<User> orderedUsers = users.OrderBy(u => u.ID).ToList();
            return orderedUsers;
        }
        public List<User> GetDescendingOrderedUsers()
        {
            List<User> sortedUsers = users.OrderByDescending(u => u.ID).ToList();
            return sortedUsers;
        }
        public List<User> GetReversedUsers()
        {
            List<User> reversedUsers = users.Reverse<User>().ToList();
            return reversedUsers;
        }
        public List<User> GetUsersPage(int pageSize, int pageIndex)
        {
            if (pageSize >= 1 && pageIndex >= 1)
            {
                List<User> pagedUsers = users.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                return pagedUsers;
            }
            else
            {
                Console.WriteLine("Error: Page size and page index must be integer numbers greater than zero");
                return new List<User>();
            }
        }

        ///<summary>
        ///Console.Writelines User's data
        ///</summary>
        ///<returns> text </returns>
        public void WriteUserData(User u)
        {
            if (u != null)
                Console.WriteLine(u.ToString());
            else Console.WriteLine("Your user is null!");
        }
        public void WriteUsersData(List<User> list)
        {
            Console.WriteLine($"Users found in list: {list.Count}");
            list.ForEach(WriteUserData);
            Console.WriteLine();
        }
        public void WriteUsersData(Dictionary<int, User> dict)
        {
            Console.WriteLine($"Users found in dictionary: {dict.Count}");
            dict.Keys.ToList().ForEach(i => Console.WriteLine($"key: {i} value: ID ={dict[i].ID}: {dict[i].Name} {dict[i].Surname}"));
            Console.WriteLine();
        }
    }
}
