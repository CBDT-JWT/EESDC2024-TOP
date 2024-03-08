# README
## 开发团队
- csq 清华大学电子工程系
- zyc 清华大学计算机科学与技术系
- jwt 清华大学电子工程系
## 玩法介绍
- 基本玩法(目前实现了经典模式)
    - 用鼠标左键拖动球员,会显示轨迹预判,可以通过同时拖动鼠标滚轮调节"加塞"程度实现弧线球,可以将球员拖回原位后释放取消操作.
    - 球员飞出场地边界后自动传送回原位;默认红方先手,时间超过60秒或一方得3分后自动结束游戏,并显示结算页面.
- ~~有待完成的~~拓展功能
    - 人机模式:供ai调用的接口已经写好
    - 选择球员功能:开局前双方可以选择球员和阵型,不同球员具有不同的数值,后续也会加入技能系统丰富玩法.本功能基本代码已经实现,但是尚未和玩法界面对接完成,有待进一步开发.
    - 局域网联机功能:~~可以用来在水课上和同学游玩~~
## 有待解决的bug(开发日志)
- 回合转换:红方切换为蓝方没有延迟,但蓝方切换到红方有延迟
- 从3v3改成5v5之后判断静止的函数需要重新写.