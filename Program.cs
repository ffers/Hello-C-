using helloapp;


MountainNavigation.LetsStartNewJourney();
int[,] map = MountainNavigation.GetThePlanetMap();
(int x, int p) = MountainNavigation.GetShipPosition();

bool finished = MountainNavigation.MoveTheSpaceShip(0, 0);

while (finished == false)
{
    if (map[x - 1, p] == 0){
        finished = MountainNavigation.MoveTheSpaceShip(-1, 0);
        (x,p) = MountainNavigation.GetShipPosition();

    }
    else if (map[x, p - 1] == 0){
        finished = MountainNavigation.MoveTheSpaceShip(0, -1);
        (x,p) = MountainNavigation.GetShipPosition();
    }
    else if (map[x, p + 1] == 0) {
                
        finished = MountainNavigation.MoveTheSpaceShip(0, +1);
        (x,p) = MountainNavigation.GetShipPosition();
               if (map[x - 1, p] == 1)
                    finished = MountainNavigation.MoveTheSpaceShip(0, +1);
                    (x,p) = MountainNavigation.GetShipPosition();
                    if (map[x - 1, p] == 1)
                        finished = MountainNavigation.MoveTheSpaceShip(0, +1);
                        (x,p) = MountainNavigation.GetShipPosition(); 
                    
                    
            }
}
Console.WriteLine($"Road ship: {map[x-1,p]}");
