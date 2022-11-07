import axios from 'axios';
export default {

    AddProcessingResponses(repliesInfo) {
        return axios.post(`/api/Replies/AddReply`, repliesInfo)
      //  return axios.post(`http://mail:82/api/Replies/AddReply`, repliesInfo)
    },

    GetProcessingResponses() {
        return axios.get(`/api/Replies/GetReplies`)
      //  return axios.get(`http://mail:82/api/Replies/GetReplies`)
    },

    DeleteResponsesService(id) {
        return axios.delete(`/api/Replies/DeleteReply?replyId=${id}`);
     //   return axios.delete(`http://mail:82/api/Replies/DeleteReply?replyId=${id}`);
    },

}