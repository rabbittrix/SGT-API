using System.Collections.Generic;
using System.Linq;
using SGTwebAPI.Models;

namespace SGTwebAPI.Repository {
    public class TodoItemRepository : ITodoItem {

        private readonly TodoContext _context;
        public TodoItemRepository (TodoContext ctx) {
            _context = ctx;
        }
        public void add (TodoItem item) {
            _context.TodoItems.Add (item);
            _context.SaveChanges ();
        }

        public TodoItem Find (long id) {
            return _context.TodoItems.FirstOrDefault (i => i.id == id);
        }

        public IEnumerable<TodoItem> GetAll () {
            return _context.TodoItems.ToList ();
        }

        public void Remove (long id) {
            var entity = _context.TodoItems.First (i => i.id == id);
            _context.TodoItems.Remove (entity);
            _context.SaveChanges ();
        }

        public void Update (TodoItem item) {
            _context.TodoItems.Update (item);
            _context.SaveChanges ();
        }
    }
}