CREATE UNIQUE INDEX Complaint_UserId_SpammerId_Unique ON "Complaint" ("UserId", "SpammerId");
CREATE UNIQUE INDEX Complaint_UserId_SmsHash_Unique ON "Complaint" ("UserId", "SmsHash");
