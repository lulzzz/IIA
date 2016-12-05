
# KQ Analytics 3

KQ Analytics version 3.x

## About

KQ Analytics provides a simple and open analytics solution for your internet service.
KQ can be used everywhere from webpages to desktop apps to mobile apps to gain valuable analytics data.

## Rearchitecturing from v2
[KQ Analytics 2](https://github.com/exaphaser/KQAnalytics)
was built on PHP.
KQ Analytics 3 is being rebuilt from scratch as a partial port of v2.0, but will be designed in a more extensible way.
It will have its own standalone server which should be reverse proxied to the outside world. As a result:

- Installation will be slightly more complex (it's no longer a simple bunch of PHP scripts)
- KQ will be **much** more customizable
- Overall security will be better (as a result of using a standalone application)

## Licensing

Copyright &copy; 2016 0xFireball, IridiumIon Software. All Rights Reserved.  
Licensed under the AGPLv3.
