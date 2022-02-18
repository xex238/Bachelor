function [result] = resultPerimeterOld(path)
I = imread(path);
BW1 = im2bw(I, 0.5);
BW2 = bwmorph (BW1, 'erode', 9);
BW2 = bwmorph (BW2, 'thicken', Inf);
BW1 = BW1 & BW2;
L = bwlabel(BW2);
stats = regionprops(L, 'all');
result = stats;
end