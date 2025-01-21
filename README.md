# היכון, הכן, צא! ⏰
**משחק התארגנות שלוקח אתכם מהיום יום אל חוויה - תכננו, אספו ונצחו**

מחפשים חוויה שמאחדת תשוקה למשחקים עם מטרה חשובה? הצטרפו להרפתקה שתשפר את כישורי ההתארגנות שלכם ותעניק לכם עצמאות אמיתית - ברוכים הבאים ל'היכון, הכן צא!'.

[שחקו במשחק](https://lizachep.itch.io/final-game-house)


![Screenshot 2024-12-15 212018](https://github.com/user-attachments/assets/ac7cac38-557c-46ac-bda6-3d7f59f225df)


## מהות המשחק
המשחק הוא חוויה תלת-ממדית המיועדת למבוגרים עם לקות שכלית בינונית עד גבולית וקשיים בארגון ותכנון יומי. 
השחקנים מתמודדים עם אתגרים של התארגנות על מנת להגיע לאירועים שונים, תוך שימוש ברמזים או רשימות. בכל חדר בדירה, הם צריכים לאסוף פריטים חיוניים כמו בגדים, אוכל ונעליים, תוך כדי פתרון משחקים קטנים ודילמות חווייתיות.
בסוף המשחק, השחקנים מקבלים דירוג על כישורי ההתארגנות שלהם בהתאם לניקוד שהשיגו.
המטרה של המשחק היא לעזור לקהל היעד לאמץ כישורי התארגנות ובכך להגדיל את עצמאותם.

[formal elemnts](https://github.com/Liza-Gaming/Ready-Set-Go/blob/main/formal-elements.md)

[dramatic elements](https://github.com/Liza-Gaming/Ready-Set-Go/blob/main/dramatic-elements.md)
## תכונות עקריות
- חוויה תלת-ממדית מרתקת: סביבה וירטואלית שמחקה את המציאות אותה שחקננים יכולים לחקור.
- אתגרים יומיומיים: איסוף פריטים חיוניים בכל חדר, כגון בגדים, אוכל ונעליים.
- משחקים קטנים ודילמות: פתרון בעיות ולקיחת החלטות לשיפור הקוגנטיביות.
- מערכת דירוג: קבלת משוב מיידי על ביצועים וכישורי התארגנות.

![Screenshot 2024-11-27 113004](https://github.com/user-attachments/assets/b2121c8a-ffba-4e60-b5f2-7617a50a7d6d)

## מבנה בקבצים (מתעדכן)
```bash
Assets/
│
├── Scenes/
│   ├── Intro
│   ├── Sample Scene
│   ├── Stove
│   ├── Fridge
│   ├── Wardrobe
│   ├── Desk
│   ├── Towel
|   ├── OpenDoor
|   ├── Instractions
|   ├── ChooseTime
|   ├── GameOver
|   └── Win
|
├── Scripts/
│   ├── RetryGame/
|   |   ├── WinSceneController.cs
|   |   └── RetryGame.cs
│   │
│   ├── Intro Scene/
│   │   ├── ButtonScript.cs
│   │   └── IntroVideoPlayer.cs
│   │
│   ├── Kitchen Scene/
│   │   ├── Fridge/
│   │   │   └── DisplayImage.cs
│   │   └── Stove/
│   │       └── StoveSliderBar.cs
│   │
│   ├── Wardrobe Scene/
│   │   ├── BasketBehavior.cs
│   │   ├── BasketMover.cs
│   │   ├── ClothingSpawner.cs
│   │   ├── Mover.cs
│   │   └── Prefabs/
│   │
│   ├── Instructions/
|   |   └── slideshow.cs
|   |   
|   ├── OpenDoorScene/
|   |    └── HoverDisplay.cs   
|   |
|   ├── ChooseTimeScene/
|   |    ├── TimeSettings.cs
|   |    └── TimeSelectionManager.cs
│   │
│   ├── Player/
│   │   ├── MoveLogic/
│   │   │   ├── CameraBob.cs
|   |   |   ├── KeyBoardController.cs
│   │   │   └── Movement.cs
│   │   ├── ButtonHandler.cs
│   │   ├── PlayerManager.cs
│   │   ├── HoverMove.cs
│   │   └── MissionTrigger.cs
│   │
│   ├── Utils/
│   │   ├── SceneController.cs
│   │   ├── SceneLoader.cs
│   │   ├── SliderBar.cs
|   |   ├── TaskInstructions.cs
│   │   ├── Timer.cs
│   │   ├── UIManager.cs
│   │   ├── Selection.cs
│   │   ├── SelectItems.cs
│   │   ├── SliderController.cs
│   │   ├── MissionTrigger.cs
│   │   ├── DisplayImage.cs
|   |   ├── DoorInteraction.cs
│   │   └── AudioManager.cs
│   │
└── └── UI/
```




**פיתוח המשחק:** אליזבט צ'פורקו

**צוות ריפוי בעיסוק:**
עינב כהן, בנייה קליין ואוריה משולם



