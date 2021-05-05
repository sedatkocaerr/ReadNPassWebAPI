﻿using Microsoft.AspNetCore.Mvc;
using ReadNPassWebAPI.AppServices.Interfaces;
using ReadNPassWebAPI.AppServices.ViewModels;
using System;
using System.Threading.Tasks;

namespace ReadNPassWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController :  ControllerBase
    {

        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBook(Guid Id)
        {
            var response = _bookService.GetById(Id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookViewModel bookViewModel)
        {
            var response = await _bookService.AddBook(bookViewModel);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookViewModel bookViewModel)
        {
            var response = await _bookService.UpdateBook(bookViewModel);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var response = await _bookService.GetAll();
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(Guid Id)
        {
            var response = await _bookService.RemoveBook(Id);
            return Ok(response);
        }
    }
}