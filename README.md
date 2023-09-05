## Space Invaders

# Bewegungen in WinForms mit oder ohne gedrückte Tasten

# Einleitung

__Was ist Windows Forms?__

`Windows Forms` ist neben der 'normalen' Konsole ein Programm in Visual Studio, das dem Benutzer ermöglicht, in verschiedenen Feldern Features einzufügen. Mit `Windows Forms` kann man mit den Feautures wie in der Konsole den Benutzer zu einer Eingabe auffordern, jedoch kann man mit den Labels und anderen Sachen die Gestaltung schöner und übersichtlicher als auf dn, da unser Spiel Space Invaders mit diesem Programm einfach zu programmieren ist.

__Was ist Space Invaders?__

Space Invaders ist ein japanisches Videospiel, in dem man mit einem Raumschiff Aliens abschiesst. Der Spieler steuert das Raumschiff mit den rechten und linken Pfeiltasten und schiesst Geschosse mit der Leertaste. Jedes Level beginnt mit mehreren Reihen regelmässig angeordneter Aliens, die sich ständig horizontal und dabei nach und nach abwärts bewegen. Der Spieler selbst hat einen unbegrenzten Munitionsvorrat, kann aber erst dann ein neues Geschoss abfeuern, wenn das vorige vom Bildschirm verschwunden ist. Wenn es einem der Aliens gelingt, den unteren Bildschirmrand zu erreichen und neben der Kanone zu landen, verliert der Spieler eines seiner Leben.

## Code

```csharp
  // Move Invaders Left or Right
                for (int i = 1; i <= numinvaders; i++) // Die Variable, damit das Bild sich bewegt
                {
                    PictureBox img = invader[i];
                    img.Left += movement;
                }

                cycle++;
                if (cycle == 62)
                {
                    movement *= -1;
                    cycle = 0;

                    // Move invaders a little down
                    for (int i = 1; i <= numinvaders; i++)
                    {
                        PictureBox img = invader[i];
                        img.Top += movement2;
                    }
                    down++;
                }
                
// Player Input Routine
        public void frmInvaders_KeyPress(object sender, KeyPressEventArgs e)
        {
            int n = e.KeyChar; // Tastatur

            // Left
            if (gamestart && (n == 52  n == 97) && Defender.Left > 25)
            {
                Defender.Left -= 15;
            }

            // Right
            if (gamestart && (n == 54  n == 100) && Defender.Left < 720)
            {
                Defender.Left += 15;
            }
        }
```

## Video

[Video Spiel](https://youtu.be/oDYmfFeIIhA "Video Spiel")

