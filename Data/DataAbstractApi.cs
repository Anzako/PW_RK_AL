using System;

namespace Data
{
    public abstract class DataAbstractApi
    {
        public static DataAbstractApi CreateApi(int width, int height)
        {
            return new DataApi(width, height);
        }

        public abstract int getBoardWidth();
        public abstract int getBoardHeight();
        public abstract Ball generate();
        public abstract void addBall(Ball ball);
        public abstract Ball getBallFromList(int indeks);
        public abstract int getAmount();

    }
    internal class DataApi : DataAbstractApi
    {
        private Board board;
        private BallList ballList;
        public DataApi(int width, int height)
        {
            board = new Board(width, height);
            ballList = new BallList();
        }

        public override int getBoardWidth()
        {
            return board.Width;
        }

        public override int getBoardHeight()
        {
            return board.Height;
        }

        public override Ball generate()
        {
            return ballList.generateBall(getBoardWidth(), getBoardHeight());
        }

        public override void addBall(Ball ball)
        {
            ballList.addBall(ball);
        }

        public override Ball getBallFromList(int indeks)
        {
            return ballList.getBall(indeks);
        }
        public override int getAmount()
        {
            return ballList.getAmount();
        }
    }
}
