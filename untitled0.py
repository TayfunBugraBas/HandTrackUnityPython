import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

width , height = 1280,720

cap = cv2.VideoCapture(0)
cap.set(3,width)
cap.set(4,height)


detector = HandDetector(maxHands = 2, detectionCon = 0.8)


uSocket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)


WinName = "test"

while True:
    success, img = cap.read()
    img = cv2.flip(img,1)
    
    
    
    hands, img = detector.findHands(img)
    
    data = []
    
    if hands:
        hand = hands[0]
        
    
        lmList = hand['lmList']
        
        for lm in lmList:
            data.extend([lm[0],height - lm[1],lm[2]])
            print(data)
            uSocket.sendto(str.encode(str(data)), serverAddressPort)
            
    if len(hands) == 2:
        hand = hands[0]
        hand1 = hands[1]
        
    
        lmList = hand['lmList']
        lmList = hand1['lmList']
        
        for lm in lmList:
            data.extend([lm[0],height - lm[1],lm[2]])
            print(data)
            uSocket.sendto(str.encode(str(data)), serverAddressPort)
        
    
    img  =cv2.resize(img, (0,0),None,0.5,0.5)
    cv2.imshow(WinName, img)
    cv2.waitKey(1)
    



