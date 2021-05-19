# -*- coding: utf-8 -*-
"""
Spyder Editor

This is a temporary script file.
"""
import cv2
import numpy as np
import sys

#PATH = r'C://Users//hscc//Desktop//test.png'
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
def ScoreV2(img1, img2):
    
    # img11111
    lower = np.array([100, 5, 5])
    upper = np.array([255, 255, 254])
    mask1 = cv2.inRange(img1, lower, upper)
    Red1 = np.count_nonzero(mask1)
    
    Button_lower = np.array([0, 0, 0])
    Button_upper = np.array([56, 51, 46])
    mask2 = cv2.inRange(img1, Button_lower, Button_upper) 
    Button1 = np.count_nonzero(mask2)
    
    All1 = mask1.size

    
    # img22222
    mask3 = cv2.inRange(img2, lower, upper)
    #plt.imshow(mask1)
    Red2= np.count_nonzero(mask3)
    
    mask4= cv2.inRange(img2, Button_lower, Button_upper) 
    #plt.imshow(mask2)
    Button2 = np.count_nonzero(mask4)

    All2 = mask4.size
    
    
    ans = (Red1 + Red2 + Button1 + Button2) / (All1 + All2)
    print(ans)
    #rint((Red + Button)/All)
    return ans

def Split_Image(img):
    StartX, StartY = 0, 0
    EndX, EndY = img.shape[0], img.shape[1]
    MidX, MidY = (EndX //2), (EndY // 2)
    res1 = img[StartX:StartX+(MidX - StartX), StartY:StartY+(MidY - StartY)]

    res1 = img[StartX:StartX+(MidX - StartX), StartY:StartY+(MidY - StartY)]
    res2 = img[MidX: MidX + (EndX - MidX), StartY:StartY+(EndY - StartY)]
    return res1, res2


if __name__ == '__main__':
    res1, res2 = Split_Image(Crop_Image(sys.argv[1]))
    print(ScoreV2(res1, res2))





