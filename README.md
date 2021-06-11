# Quad tree and image compressor
 A WinForm program that can generate a quad tree for a random set of points, and can also compress images using quad trees.
## Point parameters
 Points amount - Select how many random points the program will generate.
 
 Node capacity - How many points in a node until it splits into four.
 
 Click start to get random points and their quad tree, Start moving points to start the random movement of points
## Image parameters
 Color tolerance - Sets the color tolerance for grouping colors Abs(r1,g1,b1 - r2,g2,b2 < tolerance) the bigger the tolerance the lesser nodes are made.
 
 Desired ratio - How much of a node has to be covered with a color group set by the tolerance for it not to split anymore (max 1).
## Output images
 The quad tree image is saved under the name "quadTreeBitmap.jpg" while the compressed image made using the tree is saved under "compressed.jpg".
