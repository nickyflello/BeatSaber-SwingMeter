
# Swing Meter
Displays swing angle meters on the sides of the track.
When the meter is full, a full swing has been swung.

The meters are dived into four quadrants.
The left and right meters are for the left and right sabers.
The top/bottom half of the meters are for swinging high and low enough.

For example, if the top left meter is not full, you will need to swing higher with your left saber.

![swing meter](https://user-images.githubusercontent.com/12634471/105147681-5e71dc00-5ab6-11eb-952e-f46749515722.PNG)
## Requirements
- Beat Saber version 1.13+
- BSUtils 1.4.1+
- BSIPA 4.0.5+
- SiraUtil 2.3.1+

## Limitations
- This mod only tracks up and down notes (Dot, Left, and Right are ignored).
	- Angled notes will count as up or down notes
- There is a delay of 0.4 seconds before the meter UI updates. This is when the post-swing is finished.

## Config Settings
|Variable Name|Description|
|-|-|
|***Enabled***|Is this mod enabled?|
|***ShowPreSwing***|Apply meter updates with the pre-swing?|
|***ShowPostSwing***|Apply meter updates with the post-swing?|
|***OffsetX***|left/right offset of the UI display|
|***OffsetZ***|forward/backward offset of the UI display|
|***SizeX***|width of the UI display|
|***SizeY***|height of the UI display|