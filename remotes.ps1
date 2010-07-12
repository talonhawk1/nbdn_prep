("bcbond","talonhawk1","reconcadre","cbs4385","kaungyam") | foreach-object {
  git remote add $_ git://github.com/$_/nbdn_prep.git
}
