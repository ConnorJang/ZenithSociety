Students:

Brayden Traas
A00968178
brayden@tra.as

Connor Jang
A00874888
Cjang21@my.bcit.ca

Completed:
Everything

URL: http://connorbraydenzenithsociety.azurewebsites.net/
(be patient, it's slow)

Challenges:
- Understanding error messages
- Web.config not syncing to azure 
  - Weren't sure how to enable debug info on azure deployed site. Updating web.config and pushing to github didn't show error messages
	- Solved by editing the remote web.config file from the VS server explorer
  - Weren't sure why errors were happening on Azure but not local (seemed to be caching issues?)
- Running the website before the migration created tables which prevented the migration from working
- We used Connor's github account for code, but Brayden's Azure account for deployment. Brayden didn't see 	Connor's repo on Azure (although he had write access). We should have used a Github Organization or VSTS team. (Solved by Brayden forking Connor's repo and using it as a deployment repo).

 