import unittest
from RPS_game import play, mrugesh, abbey, quincy, kris
from RPS import player


class UnitTests(unittest.TestCase):
    print()

    def test_player_vs_quincy(self):
        print("Testing game against quincy...")
        score = play(player, quincy, 1000)
        actual = score >= 60
        self.assertTrue(
            actual,
            'Expected player to defeat quincy at least 60% of the time but got: ' + str(score) + '%')

    def test_player_vs_abbey(self):
        print("Testing game against abbey...")
        score = play(player, abbey, 1000)
        actual = score >= 60
        self.assertTrue(
            actual,
            'Expected player to defeat abbey at least 60% of the time but got: ' + str(score) + '%')

    def test_player_vs_kris(self):
        print("Testing game against kris...")
        score = play(player, kris, 1000)
        actual = score >= 60
        self.assertTrue(
            actual, 'Expected player to defeat kris at least 60% of the time but got: ' + str(score) + '%')

    def test_player_vs_mrugesh(self):
        print("Testing game against mrugesh...")
        score = play(player, mrugesh, 1000)
        actual = score >= 60
        self.assertTrue(
            actual,
            'Expected player to defeat mrugesh at least 60% of the time but got: ' + str(score) + '%')


if __name__ == "__main__":
    unittest.main()