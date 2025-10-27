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
            solve.Point = new Point() { PositionX = 12, PositionY = 5 };
            var move = new MovableAdapter(solve);
            //Act 
            move.SetPosition(new Point() {PositionX = -7 , PositionY = 3 });


            // Assert
            Assert.Equal(solve.Point, new Point() { PositionX = 5, PositionY = 8 });
        }

        [Fact]
        public void RotatableAdapterTest()
        {
            //Assign 
            var solve = new GameSpace();
            var move = new RotatableAdapter(solve);
            //Act 
            move.SetAngle(360);


            // Assert
            Assert.Equal(solve.Angle, 360);
        }
    }
}
