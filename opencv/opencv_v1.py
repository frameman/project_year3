from ctypes.wintypes import RGB     #import相關套件
import cv2
import mediapipe as mp


cap = cv2.VideoCapture(0)           #設定變數
wCam , hCam = 640 , 480
mpHand = mp.solutions.hands
hands = mpHand.Hands()
mpDrow = mp.solutions.drawing_utils


while True:
    ret,img = cap.read()            #開啟鏡頭
    if ret:                         #確保鏡頭開啟

        imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)   #將BGR轉為RGB
        result = hands.process(imgRGB)                  #偵測手掌
        #print(result.multi_hand_landmarks)
        imgHeight = img.shape[0]
        imgWidth = img.shape[1]
        if result.multi_hand_landmarks:
            for handLms in result.multi_hand_landmarks:
                mpDrow.draw_landmarks(img, handLms, mpHand.HAND_CONNECTIONS)        #匯岀手部訊息點及線
                for i,lm in enumerate(handLms.landmark):               #表示點代號
                    xPos = int(lm.x * imgWidth)
                    yPos = int(lm.y * imgHeight)
                    cv2.putText(img, str(i), (xPos-25,yPos+5), cv2.FONT_HERSHEY_SIMPLEX, 0.4, (0,255,0), 2)
                    print(i,xPos,yPos)

        cv2.imshow('img',img)
    
    if cv2.waitKey(1) == ord('q'):  #當按下q則關閉鏡頭
        break;
