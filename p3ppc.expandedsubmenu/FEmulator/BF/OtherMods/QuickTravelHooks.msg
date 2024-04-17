[msg STOP_INTO_MYROOM_LAST_DA_2]
[s]> You must go to Tartarus...
[n][w][e]

[msg FIRST_DAY]
[s]> You are tired today...
[n][w][e]
[s]> You should go to bed early...
[n][w][e]

[sel BEDIN_SEL top]
[s]Sleep[e]
[s]Don't sleep yet[e]

[msg NIGHT_BED]
[s]> Go to bed early?
[n][w][e]

[sel YESNO_SEL_2 top]
[s]Yes[e]
[s]No[e]

[msg STOP_GO_OUT_YUKARI [Yukari]]
[s][bup 2 1 65535 0]You're not allowed to go out,
[n]since it's past curfew.
[n][w][e]

[msg STOP_GO_OUT_MITSURU [Mitsuru]]
[s][bup 4 1 65535 0]We cannot allow you to go out
[n]after dark.
[n][w][e]
[s]Sorry, but rules are rules.
[n][w][e]

[msg STOP_GO_OUT]
[s]> You aren't allowed to go outside
[n]at nighttime.
[n][w][e]

[msg STOP_GO_OUT_MITSURU_0419 [Mitsuru]]
[s][bup 4 1 65535 0]Have you finished your homework?
[n][w][e]

[msg STORM_COMING]
[s]> It's raining outside...
[n][w][e]

[msg STORM_COMING_JUNPEI [Junpei]]
[s][bup 5 1 65535 0]Hey! Where do you think you're
[n]going?
[n][w][e]
[s]Forget about it! You're gonna
[n]catch a cold, dude.
[n][w][e]

[msg STOP_GOOD_0303]
[s]> Even though all you did was go to
[n]school, you feel lethargic...
[n][w][e]
[s]> You should go to sleep early tonight.
[n][w][e]

[msg STOP_BAD_0303]
[s]> It doesn't seem like the others have
[n]returned yet.
[n][w][e]
[s]> It seems it would be best if you
[n]refrained from going out tonight.
[n][w][e]

[msg STOP_GOOD_0304]
[s]> ...You are feeling tired.
[n][w][e]
[s]> You should rest...
[n][w][e]

[msg STOP_BAD_0304]
[s]> Tomorrow is Graduation Day.
[n][w][e]
[s]> It would be best if you went to bed
[n]early today.
[n][w][e]

[msg STOP_INTO_MYROOM_2]
[s]> You were told to come to the
[n]4th floor today...
[n][w][e]

[msg GO_OUT_OK]
[s]> Will you go out until dark?
[n][w][e]

[sel GOOUT_SEL top]
[s]Go out[e]
[s]Don't go out[e]

[msg GO_OUT_OK_HELP]
[s]If you go outside, when you come
[n]back to the dorm, it will become
[n]nighttime.
[n][w][e]
