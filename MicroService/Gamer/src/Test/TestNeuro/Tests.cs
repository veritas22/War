using System.Text;
using Logic;
using RabbitMQ.Client;

namespace TestNeuro
{

    public class Tests
    {

        [Fact]
        public void MovableAdapterTest()
        {
            //Assign 
            var solve = new GameSpace();
            var move = new MovableAdapter(solve);
            //Act 
            move.SetPosition(new Point() {PositionX = 2 , PositionY = 3 });


            // Assert
            Assert.NotNull(move);
        }

        [Fact]
        public void RotatableAdapterTest()
        {
            //Assign 
            var solve = new GameSpace();
            var move = new RotatableAdapter(solve);
            //Act 
            move.SetAngle(20);


            // Assert
            Assert.NotNull(move);
        }
    }
}
