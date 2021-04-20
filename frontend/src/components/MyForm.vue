<template>
    <div>
        <v-card>
          <v-snackbar v-model="sendBar" absolute top right color="success">
            <span>Commentary send!</span>
          </v-snackbar>
          <v-snackbar v-model="errorBar" absolute top right color="error">
            <span>{{errorMessage}}</span>
          </v-snackbar>
        </v-card>
        <v-form ref="form" @submit.prevent="submit">
          <v-text-field 
            v-model="form.mail"
            :rules="rules.mail"
            color="purple darken-2"
            label="E-Mail"
            required
          ></v-text-field>
          <v-text-field
            v-model="form.name"
            :rules="rules.name"
            color="purple darken-2"
            label="Name"
            required
          ></v-text-field>
          <v-textarea
            v-model="form.commentary"
            :rules="rules.commentary"
            :counter="250"
            color="teal"
            required
            label="Your's comment">
          </v-textarea>
            <v-btn 
              :disabled="!formIsValid"
              color="primary"
              type="submit"
              elevation="2"
              outlined
              >
              Send commentary
            </v-btn>
        </v-form>
    </div>
</template>

<script>
export default  {
    props: ['value'],
    data() {
        const defaultForm = Object.freeze({
            mail: '',
            name: '',
            commentary: ''
        })
        return {
            form: Object.assign({}, defaultForm),
            rules: {
                name: [val => (val || '').length > 0 || 'This field is required'],
                commentary: 
                  [
                    val => (val || '').length > 5 || 'Comment must contain more than 5 characters',
                    val => (val || '').length <= 250 || 'Too much characters'
                  ],
                mail: 
                [
                  val => (val || '').length > 0 || 'This field is required',
                  val => /.+@.+\..+/.test(val) || 'Wrong format'
                ]
            },
            sendBar: false,
            errorBar: false,
            errorMessage: '',
            defaultForm
        }
    },

    computed: {
        formIsValid(){
            return(this.form.name && this.form.mail && this.form.commentary)
        }
    },

    methods:{
        resetForm(){
            this.form = Object.assign({}, this.defaultForm);
            this.$refs.form.reset()
        },
        submit(){
            
            this.$api.post("Comments",{
                name: this.form.name,
                eMail: this.form.mail,
                commentary: this.form.commentary,
                SendDate: new Date().toJSON()
            }).then(response =>{
              if(response != undefined){
                this.$emit('added',response);
                this.sendBar = true;
                this.resetForm();
              }
            }).catch(error =>
            {
              console.log(error);
              this.errorMessage = error.message;
              this.errorBar = true;
            })
        }
    }
}
</script>

<style scoped>
form {
 margin: 10px 2rem;
 border: 2px solid black;
}
form *{
  margin: 10px;
}
</style>