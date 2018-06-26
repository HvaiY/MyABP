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
            //create test data here...
            //�Զ������Թ���
            _context.Tasks.AddRange(
                new Task("Follow the white rabbit", "Follow the white rabbit in order to know the reality."),
                new Task("Clean your room") { State = TaskState.Completed }
            );
          
        }
    }
}