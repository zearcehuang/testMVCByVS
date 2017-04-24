啟動iisexpress指令
iisexpress /site:testWebAPI
啟動後按Q停止

private TPDBtestEntities db = new TPDBtestEntities();

        // GET: odata/CodeData
        [EnableQuery]
        public IQueryable<DT311_ACode> GetCodeData()
        {
            return db.DT311_ACode;
        }

        // GET: odata/CodeData(5)
        [EnableQuery]
        public SingleResult<DT311_ACode> GetDT311_ACode([FromODataUri] string key)
        {
            return SingleResult.Create(db.DT311_ACode.Where(dT311_ACode => dT311_ACode.CODE_TYPE == key));
        }

        // PUT: odata/CodeData(5)
        public IHttpActionResult Put([FromODataUri] string key, Delta<DT311_ACode> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DT311_ACode dT311_ACode = db.DT311_ACode.Find(key);
            if (dT311_ACode == null)
            {
                return NotFound();
            }

            patch.Put(dT311_ACode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DT311_ACodeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dT311_ACode);
        }

        // POST: odata/CodeData
        public IHttpActionResult Post(DT311_ACode dT311_ACode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DT311_ACode.Add(dT311_ACode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DT311_ACodeExists(dT311_ACode.CODE_TYPE))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Created(dT311_ACode);
        }

        // PATCH: odata/CodeData(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] string key, Delta<DT311_ACode> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DT311_ACode dT311_ACode = db.DT311_ACode.Find(key);
            if (dT311_ACode == null)
            {
                return NotFound();
            }

            patch.Patch(dT311_ACode);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DT311_ACodeExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(dT311_ACode);
        }

        // DELETE: odata/CodeData(5)
        public IHttpActionResult Delete([FromODataUri] string key)
        {
            DT311_ACode dT311_ACode = db.DT311_ACode.Find(key);
            if (dT311_ACode == null)
            {
                return NotFound();
            }

            db.DT311_ACode.Remove(dT311_ACode);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DT311_ACodeExists(string key)
        {
            return db.DT311_ACode.Count(e => e.CODE_TYPE == key) > 0;
        }
		
		
		
		private DT311_ACode_Repository _codeDataRepository;

        CodeDataController()
        {
            _codeDataRepository = new DT311_ACode_Repository();
        }

        //[Route("CodeData/GetCode")]
        // GET: odata/CodeData
        [EnableQuery]
        public IQueryable<DT311_ACode> GetCode()
        {
            return _codeDataRepository.GetCodeData();
        }

        //[Route("CodeData/GetItem/{codetype}/{id}")]
        [Authorize(Roles = "Administrator"), EnableQuery]
        public DT311_ACode GetItem(string CODE_TYPE, string CODE)
        {
            DT311_ACode Acode = _codeDataRepository.GetByKey(CODE_TYPE, CODE);
            if (Acode == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Acode;
        }

        protected override void Dispose(bool disposing)
        {
            _codeDataRepository.Dispose();
            base.Dispose(disposing);
        }