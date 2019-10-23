using System.Collections.Generic;
using SGTwebAPI.Models;
namespace SGTwebAPI.Repository {
    public interface ITodoItem {
        void add (TodoItem item);
        IEnumerable<TodoItem> GetAll ();
        TodoItem Find (long id);
        void Remove (long id);
        void Update (TodoItem item);
    }
}