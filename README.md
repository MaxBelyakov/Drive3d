# Drive3d
Simple 3d drive simulator

v.1.0:
- level design;
- car asset (standard unity asset with script);
- textures;
- camera stabilizator.

v.1.1:
- checkpoints system;
- finish line;
- time panel;
- directional arrow.

v.1.2:
- calculating Lap Time;
- calculating Best Time.

v.1.3:
- 3-2-1 counter;
- enemy car;
- enemy car moving by checkpoints.

v.1.4:
- fix: freeze enemy car while countdown;
- fix: slow down enemy car turning speed;
- enemy car move back when get stuck;
- player car is red, enemy car is black.

v.1.5:
- minimap render;
- laps counter;
- statistics screen after last lap finish.

v.1.6:
- fix: laptime freeze when countdown;
- add second enemy car;
- optimize check best time script.

v.1.6.1:
- fix check best time script;
- lap counting for each car;
- lap time counting for each car;
- stop enemy cars when its finish game.

v.1.7:
- statistics screen visual update;
- rating system.

v.1.7.1:
- show cars race time in statistics;
- optimize lap time manager script (change logic of calculation).

v.1.8:
- minimap car markers;
- car markers stabilizator;
- clear and optimize camera stabilizator script.

v.1.9:
- fix: move enemy cars targets relatively each other;
- fix: change enemy behavior to never break, because of bug in AI script;
- fix: add extra divider to checkpoint rating variable, because of rating bug when checkpoint become more than 10;
- blinking checkpoint markers on minimap;
- new track checkpoints, full race circle;
- optimize checkpoint list script, collect all checkpoints in list that fills in unity inspector;
- disable directional arrow;
- improve finish checkpoint prefab, join it with checkpoint collider;
- improve checkpoint prefab, add identification columns at the edges.
