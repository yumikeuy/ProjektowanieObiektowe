using Lab1.Library.Entities.GameObjects;
using Lab1.Library.Entities.GameObjects.Items.Weapons;
using Lab1.Library.Entities.GameObjects.Money;
using Lab1.Library.Interfaces;
using Lab1.Library.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Library.Entities
{
    public class Board : IBoard
    {
        private readonly int _width;
        private readonly int _height;

        private IGameObject[,] _data;
        private IPlayer _player;

        public Point PrintAt { get; set; } = new Point(1, 1);
        
        public Board(int width, int height, IPlayer player)
        {
            _width = width;
            _height = height;
            _data = new IGameObject[_width, _height];
            _player = player;
            BoardDefaultInit(player.Pos);
        }
        public void BoardDefaultInit(Point playerStartPos)
        {
            var randomizer = new Random();

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (i == playerStartPos.X && j == playerStartPos.Y) _data[j, i] = new EmptyGameObject(new(j, i));
                    int r = randomizer.Next(1, 100);
                    switch (r)
                    {
                        case <= 10:
                            _data[j, i] = new Wall(new(j, i));
                            break;
                        case <= 11:
                            _data[j, i] = new Coin(new(j, i));
                            break;
                        case <= 12:
                            _data[j, i] = new Gold(new(j, i));
                            break;
                        case <= 13:
                            _data[j, i] = new MachineGun(new(j, i));
                            break;
                        case <= 14:
                            _data[j, i] = new ClassicBow(new(j, i));
                            break;
                        default:
                            _data[j, i] = new EmptyGameObject(new(j, i));
                            break;
                    }
                }
            }
        }
        public IPrintable Text()
        {
            Printable lines = new();
            for (int i = -1; i <= _height; i++)
            {
                var line = new TextPos(new(PrintAt.X, PrintAt.Y + i));
                for(int j = -1; j <= _width; j++)
                {
                    if (i == _player.Pos.Y && j == _player.Pos.X)
                    {
                        lines.AddText(line);
                        line = new(new(j + 3, i + 1));
                        continue;
                    }
                    if (i == -1 || i == _height)
                        line.Text += '-';
                    else if (j == -1 || j == _width)
                        line.Text += "|";
                    else
                        line.Text += _data[j, i].Text().GetText();
                }
                lines.AddText(line);
            }

            if (_data[_player.Pos.X, _player.Pos.Y].Pickable())
                lines.AddText(new TextPos("Press \"E\" to pick up.", new(PrintAt.X, PrintAt.Y + _height + 1)));
            else
                lines.AddText(new TextPos("                       ", new(PrintAt.X, PrintAt.Y + _height + 1)));

            return lines;
        }

        public bool TryMovePlayer(IPlayer player, Point pos)
        {
            var currentPos = player.Pos;

            if(!IsNextTo(currentPos, pos) || !IsInside(pos)) return false;
            if (!GetAt(pos).CanBeGoneThrough) return false;
                
            player.Move(pos);
            
            return true; 
        }

        public bool TryPickUp(IPlayer player)
        {
            if (GetAt(player.Pos).Pick(player.State))
            {
                SetAt(player.Pos, new EmptyGameObject(player.Pos));
                return true;
            }

            return false;
        }
        public bool TryDrop(IPlayer player)
        {
            if (GetAt(player.Pos).IsEmpty)
            {
                var item = player.State.Drop();
                if (item != null)
                {
                    SetAt(player.Pos, item);
                    return true;
                }
            }

            return false;
        }

        private IGameObject GetAt(Point pos)
        {
            return _data[pos.X, pos.Y];
        }
        private void SetAt(Point pos, IGameObject gameObject)
        {
            _data[pos.X, pos.Y] = gameObject;
        }

        private bool IsInside(Point pos)
        {
            return pos.X >= 0 && pos.Y >= 0 && pos.X < _width && pos.Y < _height;
        }
        private bool IsNextTo(Point playerPos, Point pos)
        {
            return ((Math.Abs(playerPos.X - pos.X) <= 1 && playerPos.Y == pos.Y) ||
                    (Math.Abs(playerPos.Y - pos.Y) <= 1 && playerPos.X == pos.X));
        }
    }
}
