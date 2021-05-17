# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""
import cv2
import numpy as np
import sys

#PATH = r'C://Users//hscc//Desktop//1.png'
#img = cv2.imread(PATH)
#img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

def Crop_Image(PATH):
    img = cv2.imread(PATH)
    img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    
    lower_pink = np.array([255, 0, 255])
    upper_pink = np.array([255, 0, 255])
    mask = cv2.inRange(img, lower_pink, upper_pink) 
    Edge = np.nonzero(mask)

    #Get the Min & Max Position
    StartX, StartY = min(Edge[0]), min(Edge[1])
    EndX, EndY = max(Edge[0]), max(Edge[1])
    
    w = EndX - StartX
    h = EndY - StartY
    crop_img = img[StartX:StartX+w, StartY:StartY+h]
    
    return crop_img

#Input is cv2 image 
def Score(img):
    lower = np.array([100, 5, 5])
    upper = np.array([255, 255, 254])
    mask1 = cv2.inRange(img, lower, upper) 
    #plt.imshow(mask1)
    Red = np.count_nonzero(mask1)
    
    Button_lower = np.array([0, 0, 0])
    Button_upper = np.array([56, 51, 46])
    mask2 = cv2.inRange(img, Button_lower, Button_upper) 
    #plt.imshow(mask2)
    Button = np.count_nonzero(mask2)
    
    All = mask1.size
    
    print(((Red + Button)/All) * 100) 
    return ((Red + Button)/All) * 100


if __name__ == '__main__':
    print( Score(Crop_Image(sys.argv[1])))





