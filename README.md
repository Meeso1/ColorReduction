## Color reduction tool

This tool visualizes a few color reduction algorithms:
1. Average dithering
2. Ordered dithering (with random and consecutive pattern position selection)
3. Dithering with error propagation
4. Popularity algorithm

It also can encode an image into it's YCbCr representation, and decode it back to RGB.

### Color reduction

To start, click the 'Choose image' button. This will open a file selection dialog. Choose a file that will be used in visualizations.

Choose reduction algorithm from the dropdown menu. Parameters can be tweaked with input boxes below. 'K (red)', 'K (green)' and 'K (blue)' values represent number of levels for values of red, green and blue components in colors. They are used in dithering algorithms. 'K (all)' parameter represents a number of most popular colors that the popularity algorithm will reduce an image to. 

Valid values for all fields are integers bigger than 1. There is no upper limit, although algorithms will run slower for bigger inputs.

To start processing, click 'Apply' below the image selection button. Image with reduced colors will be displayed on the right. Operation will be timed, and elapsed time will be displayed in the lower left corner.

### YCbCr - RGB conversion

To encode an image, choose it as described above, and then click 'Apply' button in the 'Y Cb Cr' section. Operation will be timed. 3 images will appear on the right side. They represent Y, Cb and Cr components of the input image. These images will also be saved to files 'output_Y.png', 'output_Cb.png' and 'output_Cr.png', respectively. Paths are relative to application's working directory.

To decode an image, first check the 'Decode' checkbox. This will enable 3 buttons below. Clicking them will open file selection dialogs. Choose images containing respective components of the image - for example, images encoded by the step above should be suitable. Once images are chosen, click 'Apply' button below. Decoded image will be displayed on the right, and processing time will be registered. Created image will also be saved to 'output_Rgb.png' in application's working directory.

It is important to not choose a file that the output image will be written to as an input image. Doing so will result in a runtime error.