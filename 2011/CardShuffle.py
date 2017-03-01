class CardShuffle:
    def __init__(self):
        self.iTestCaseNum = int(input())
        self.iaResult = []
        for i in range(self.iTestCaseNum):
            self.fRunTestCase()

    def fRunTestCase(self):
        self.fInitTestCase()
        for i in range(self.iShuffleNum):
            self.fShuffle(i)
        self.iaResult.append(self.iCurrentPosition)

    def fInitTestCase(self):
        sInputTxt = input().split()
        self.iCardNum = int(sInputTxt[0]) #カードの枚数
        self.iShuffleNum = int(sInputTxt[1]) #シャッフルする回数
        self.iWantCard = int(sInputTxt[2]) #答えが上から何枚目のカードか
        self.iCurrentPosition = self.iWantCard #

        self.sShuffleOrder = []
        for i in range(self.iShuffleNum):
            sInputTxt = input().split()
            a1 = int(sInputTxt[0])
            a2 = int(sInputTxt[1])
            self.sShuffleOrder.append([a1,a2])
        self.sShuffleOrder.reverse()


    def fShuffle(self,iNum):
        iA = self.sShuffleOrder[iNum][0]
        iB = self.sShuffleOrder[iNum][1]

        if self.iCurrentPosition < iA+iB:
            self.iCurrentPosition += iA-1
            if self.iCurrentPosition >= iA+iB:
                self.iCurrentPosition -= iB + iA - 1

    def fOutputResult(self):
        for i in range(len(self.iaResult)):
            print("Case #"
                  + str(i + 1)
                  + ": "
                  + str(self.iaResult[i] ) )

c = CardShuffle()
c.fOutputResult()



