using System.Text;
using Logic;
using Logic.Interfase;
using RabbitMQ.Client;
using Moq;

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
            var movable = new MovableAdapter(solve);
            var move = new Move(movable);
            //Act 
            move.Execute(new Point() {PositionX = -7 , PositionY = 3 });


            // Assert
            Assert.Equal(solve.Point, new Point() { PositionX = 5, PositionY = 8 });
        }

        [Fact]
        public void Move_WhenCannotReadPosition_ThrowsException()
        {
            //Assign 
            var mockMovable = new Mock<IMovable>();
            mockMovable.Setup(m => m.GetPosition())
                .Throws(new InvalidOperationException("Невозможно прочитать положение в пространстве"));
            
            var move = new Move(mockMovable.Object);
            var velocity = new Point() { PositionX = -7, PositionY = 3 };

            //Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => move.Execute(velocity));
            Assert.Contains("Невозможно прочитать положение в пространстве", exception.Message);
        }

        [Fact]
        public void Move_WhenCannotReadVelocity_ThrowsException()
        {
            //Assign 
            var mockMovable = new Mock<IMovable>();
            mockMovable.Setup(m => m.GetPosition())
                .Returns(new Point() { PositionX = 12, PositionY = 5 });
            mockMovable.Setup(m => m.GetVelocity())
                .Throws(new InvalidOperationException("Невозможно прочитать значение мгновенной скорости"));
            
            var move = new Move(mockMovable.Object);
            var velocity = new Point() { PositionX = -7, PositionY = 3 };

            //Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => move.Execute(velocity));
            Assert.Contains("Невозможно прочитать значение мгновенной скорости", exception.Message);
        }

        [Fact]
        public void Move_WhenCannotSetPosition_ThrowsException()
        {
            //Assign 
            var mockMovable = new Mock<IMovable>();
            mockMovable.Setup(m => m.GetPosition())
                .Returns(new Point() { PositionX = 12, PositionY = 5 });
            mockMovable.Setup(m => m.GetVelocity())
                .Returns(new Point() { PositionX = 0, PositionY = 0 });
            mockMovable.Setup(m => m.SetPosition(It.IsAny<Point>()))
                .Throws(new InvalidOperationException("Невозможно изменить положение в пространстве"));
            
            var move = new Move(mockMovable.Object);
            var velocity = new Point() { PositionX = -7, PositionY = 3 };

            //Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => move.Execute(velocity));
            Assert.Contains("Невозможно изменить положение в пространстве", exception.Message);
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
