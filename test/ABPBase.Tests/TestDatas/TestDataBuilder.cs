using ABPBase.EntityFrameworkCore;
using ABPBase.Tasks;

namespace ABPBase.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly ABPBaseDbContext _context;

        public TestDataBuilder(ABPBaseDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            var neo=new Person("Neo");
            _context.People.Add(neo);
            _context.SaveChanges();
            //create test data here...
            //自动化测试构建
            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality.",neo.Id),
                new Task("Clean your room") { State = TaskState.Completed }
            );
          
        }
    }
}