//import axios from 'axios';
import SecurityService from './SecurityService.js';
import TestService from './TestService.js';
import MailService from './MailService.js';
import DocumentService from './DocumentService.js';
import DashboardService from './DashboardService.js';
import processingResponsesService from './processingResponsesService.js';
import UserService from './UserService.js';
import SectorsService from './SectorsService';
import UsersService from './UsersService';


export default {

    securityService: SecurityService,
    testService: TestService,
    mailService: MailService,
    documentService: DocumentService,
    DashboardService: DashboardService,
    processingResponsesService: processingResponsesService,
    userService: UserService,
    sectorsService: SectorsService,
    usersService: UsersService,

}